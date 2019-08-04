using UnityEngine;
using System.Collections;

public class Spike : Entity {
  
  private bool flaming;
  
  [SerializeField]
  private GameObject spark;
  
  protected override void Start() {
    base.Start();
  }
  
  protected void FixedUpdate() {
    if (rb.velocity == Vector2.zero) {
      rb.velocity += Vector2.up;
      rb.velocity += Vector2.right;
      rb.velocity *= 5f;
    }
    Move(rb.position + rb.velocity + Random.insideUnitCircle * 0.2f);
  }
  
  private void OnCollisionEnter2D(Collision2D collision) {
    OnCollisionStay2D(collision);
  }
  
  private void OnCollisionStay2D(Collision2D collision) {
    if (collision.gameObject.CompareTag("Hazard")) {
      Instantiate(spark, collision.contacts[0].point, Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.up, rb.position - collision.contacts[0].point), Vector3.forward));
    }
  }
}
