using UnityEngine;
using System.Collections;

public class Ball : Entity {
  
  [SerializeField]
  private float maxAirTime;
  [SerializeField]
  private float maxFlameTime;
  
  [SerializeField]
  private Player player;
  
  private int ricoCount;
  private int smashCount;
  [SerializeField]
  private float flameTime;
  private float airTime;
  private bool golden;
  public bool catchable;
  
  private IEnumerator Activate() {
    while (gameObject.activeSelf) {
      if (airTime > maxAirTime) {
        catchable = false;
      }
      yield return null;
      airTime += Time.deltaTime;
    }
  }
  
  public void Ignite() {
    flameTime = maxFlameTime;
  }
  
  private void ResetScore() {
    ricoCount = 0;
    smashCount = 0;
    golden = false;
    flameTime = 0f;
  }
  
  private int GetScore() {
    int score = (int)Mathf.Round(Mathf.Pow(ricoCount, 1.5f)) * 5;
    score += ricoCount * smashCount * 10;
    if (golden) score *= 2;
    return score;
  }
  
  private void OnEnable() {
    airTime = 0f;
    flameTime = 0f;
    catchable = true;
    StartCoroutine(Activate());
  }
  
  private void FixedUpdate() {
    if (catchable) {
      Move(rb.position + rb.velocity);
    }
    rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed * 1.5f);
  }
  
  private void Update() {
    if (flameTime > 0f) {
      flameTime -= Time.deltaTime;
      flameTime = (flameTime < 0f) ? 0f : flameTime;
    }
  }
  
  private void OnTriggerEnter2D() {
    if (flameTime > 0f) {
      Debug.Log("player burnt");
    }
    if (catchable) {
      player.score += GetScore();
    }
    ResetScore();
  }
  
  private void OnCollisionEnter2D(Collision2D collision) {
    ricoCount += 1;
    if (collision.gameObject.layer == LayerMask.NameToLayer("Targets")) {
      Destroy(collision.gameObject);
    }
  }
}
