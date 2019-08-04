using UnityEngine;
using System.Collections;

public class Player : Entity {
  
  private Vector2 mousePos;
  
  [SerializeField]
  private float scoreDelay;
  public int score;
  
  [Header("Components")]
  [SerializeField]
  private Animator animator;
  [SerializeField]
  private Transform eyes;
  private Vector2 eyeCentroid;
  [SerializeField]
  private GameObject puddle;
  [SerializeField]
  private Transform room;
  [SerializeField]
  private float trailRate;
  
  private IEnumerator GrowScore() {
    yield return new WaitForSecondsRealtime(scoreDelay);
    score++;
    StartCoroutine(GrowScore());
  }
  
  private IEnumerator TrailSlime() {
    yield return new WaitForSecondsRealtime(trailRate);
    Instantiate(puddle, transform.position, Quaternion.identity, room);
    StartCoroutine(TrailSlime());
  }
  
  protected override void Start() {
    base.Start();
    score = 0;
    StartCoroutine(GrowScore());
    StartCoroutine(TrailSlime());
    eyeCentroid = new Vector2(0.14f, 0.1f);
  }
  
  protected void FixedUpdate() {
    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Move(mousePos);
    // Rotate(mousePos - rb.position);
    rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed * 1.5f);
    eyes.localPosition = eyeCentroid + Vector2.ClampMagnitude(mousePos - rb.position, 1f) * 0.3f;
  }
}
