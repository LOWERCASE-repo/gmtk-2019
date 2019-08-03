using UnityEngine;
using System.Collections;

public class Player : Entity {
  
  private Vector2 mousePos;
  
  [SerializeField]
  private float scoreDelay;
  
  [Header("Debug")]
  public int score;
  
  [Header("GameObjects")]
  [SerializeField]
  private Ball ball;
  
  private IEnumerator GrowScore() {
    yield return new WaitForSecondsRealtime(scoreDelay);
    score++;
    StartCoroutine(GrowScore());
  }
  
  private void Throw() {
    if (transform.childCount == 1) {
      transform.DetachChildren();
    }
  }
  
  protected override void Start() {
    base.Start();
    score = 0;
    StartCoroutine(GrowScore());
  }
  
  protected void FixedUpdate() {
    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 mvmt = new Vector2(Input.GetAxisRaw("MoveX"), Input.GetAxisRaw("MoveY"));
    mvmt += rb.position;
    Move(mvmt);
    Rotate(mousePos - rb.position);
    if (Input.GetButton("Throw")) {
      // Instantiate(ball, transform.position, transform.rotation);
      ball.transform.position = transform.position;
      ball.transform.rotation = transform.rotation;
      ball.rb.velocity = rb.velocity + (Vector2)transform.up * 5f;
    } // TODO CHarged throws
    rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed * 1.5f);
  }
  
  private void OnCollisionEnter2D() {
    // if ball, 
  }
}
