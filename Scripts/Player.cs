using UnityEngine;
using System.Collections;

public class Player : Entity {
  
  private Vector2 mousePos;
  
  [SerializeField]
  private float maxCharge;
  [SerializeField]
  private float chargeTime;
  [SerializeField]
  private float chargeBonus;
  
  [SerializeField]
  private float scoreDelay;
  
  [Header("Debug")]
  [SerializeField]
  private float heldTime;
  public int score;
  
  [Header("GameObjects")]
  [SerializeField]
  private Ball ball;
  
  private IEnumerator GrowScore() {
    yield return new WaitForSecondsRealtime(scoreDelay);
    score++;
    StartCoroutine(GrowScore());
  }
  
  private bool charging; // TODO animator time
  private IEnumerator ChargeThrow() {
    while (Input.GetButton("Throw")) {
      heldTime += Time.deltaTime;
      yield return null;
    }
    ball.transform.position = transform.position;
    ball.transform.rotation = transform.rotation;
    float chargeMod;
    if (heldTime > chargeTime) {
      // animator.SetTrigger("Flash");
      chargeMod = maxCharge + chargeBonus;
    } else {
      chargeMod = maxCharge * heldTime / chargeTime;
    }
    ball.rb.velocity = rb.velocity + (Vector2)transform.up * chargeMod;
    charging = false;
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
    if (Input.GetButton("Throw") && !charging) {
      charging = true;
      heldTime = 0f;
      StartCoroutine(ChargeThrow());
    }
    rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed * 1.5f);
  }
  
  private void OnCollisionEnter2D() {
    // if ball, 
  }
}
