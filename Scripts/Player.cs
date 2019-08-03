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
  
  private IEnumerator ChargeThrow() {
    while (Input.GetButton("Throw")) {
      heldTime += Time.deltaTime;
      if (heldTime > chargeTime) {
        animator.SetBool("FullyCharged", true);
      }
      yield return null;
    }
    ball.transform.position = transform.position;
    ball.transform.rotation = transform.rotation;
    float chargeMod;
    if (animator.GetBool("FullyCharged")) {
      chargeMod = maxCharge + chargeBonus;
    } else {
      chargeMod = maxCharge * heldTime / chargeTime;
    }
    ball.gameObject.SetActive(true);
    ball.rb.velocity = rb.velocity + (Vector2)transform.up * chargeMod;
    animator.SetBool("Charging", false);
    animator.SetBool("FullyCharged", false);
    animator.SetBool("HasBall", false);
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
    if (Input.GetButton("Throw") && !animator.GetBool("Charging") && animator.GetBool("HasBall")) {
      animator.SetBool("Charging", true);
      heldTime = 0f;
      StartCoroutine(ChargeThrow());
    }
    rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed * 1.5f);
  }
  
  private void OnCollisionEnter2D(Collision2D collision) {
    // die i guess
  }
  
  private void OnTriggerStay2D(Collider2D collider) {
    if (animator.GetCurrentAnimatorStateInfo(0).IsName("MissingBall")) {
      ball.gameObject.SetActive(false);
      animator.SetBool("HasBall", true);
    }
  }
}
