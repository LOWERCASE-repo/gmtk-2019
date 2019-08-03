using UnityEngine;
using System.Collections;

public class Ball : Entity {
  
  // passive gain 1ps
  // bounce gives 5
  // two bounces gives 15
  // three gives 30
  
  // gold walls double points
  // spiky ball smash gives 10 + 10 * ricochets
  
  // walls chance of change every 20 points
  // rooms change at 100, 200, 400
  
  // wall chance of change increases with points
  
  [SerializeField]
  private float catchWindow;
  
  [SerializeField]
  private Player player;
  
  private int ricoCount;
  private int smashCount;
  private bool golden;
  private bool flaming;
  public bool catchable;
  
  private float airTime;
  private IEnumerator Activate() {
    while (gameObject.activeSelf) {
      if (airTime > catchWindow) {
        catchable = false;
      }
      yield return null;
      airTime += Time.deltaTime;
    }
  }
  // fixed time pause for crunch
  
  private void ResetScore() {
    ricoCount = 0;
    smashCount = 0;
    golden = false;
    flaming = false;
  }
  
  private int GetScore() {
    int score = (int)Mathf.Round(Mathf.Pow(ricoCount, 1.5f)) * 5;
    score += ricoCount * smashCount * 10;
    if (golden) score *= 2;
    
    return score;
  }
  
  private void OnEnable() {
    airTime = 0f;
    catchable = true;
    StartCoroutine(Activate());
  }
  
  private void FixedUpdate() {
    if (catchable) {
      Move(rb.position + rb.velocity);
    }
    rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed * 1.5f);
  }
  
  private void OnTriggerEnter2D() {
    if (flaming) {
      Debug.Log("player burnt");
    }
    if (catchable) {
      player.score += GetScore();
    }
    ResetScore();
  }
  
  private void OnCollisionEnter2D() {
    ricoCount += 1;
  }
  
}
