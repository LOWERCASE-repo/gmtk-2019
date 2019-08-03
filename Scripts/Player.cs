using UnityEngine;
using System.Collections;

public class Player : Entity {
  
  private Vector2 mousePos;
  
  [SerializeField]
  private float scoreDelay;
  
  [Header("Debug")]
  [SerializeField]
  private float heldTime;
  public int score;
  
  [Header("Components")]
  [SerializeField]
  private Animator animator;
  
  [Header("GameObjects")]
  [SerializeField]
  private Ball ball;
  
  private IEnumerator GrowScore() {
    yield return new WaitForSecondsRealtime(scoreDelay);
    score++;
    StartCoroutine(GrowScore());
  }
  
  protected override void Start() {
    base.Start();
    score = 0;
    StartCoroutine(GrowScore());
  }
  
  protected void FixedUpdate() {
    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Move(mousePos);
    Rotate(mousePos - rb.position);
    rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed * 1.5f);
  }
  
  private void OnCollisionEnter2D(Collision2D collision) {
  }
  
  private void OnTriggerStay2D(Collider2D collider) {
  }
}
