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
    Move(rb.position + rb.velocity + Random.insideUnitCircle * 0.2f);
  }
  
  private void OnCollisionStay2D(Collision2D collision) {
    if (collision.gameObject.name == "Player") {
      Debug.Log("player shredded");
    } else {
      Debug.Log(collision.gameObject.tag);
      if (collision.gameObject.CompareTag("Hazard")) {
        Instantiate(spark, collision.contacts[0].point, Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.up, rb.position - collision.contacts[0].point), Vector3.forward));
      }
    }
  }
}
