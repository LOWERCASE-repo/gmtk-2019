using UnityEngine;
using System.Collections;

public class Spike : Entity {
  
  private bool flaming;
  
  [SerializeField]
  private GameObject spark;
  [SerializeField]
  private GameObject wallSpark;
  
  [SerializeField]
  private AudioSteve aud;
  
  protected override void Start() {
    base.Start();
    aud = GameObject.FindWithTag("Steve").GetComponent<AudioSteve>();
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
    if (collision.gameObject.CompareTag("Hazard")) {
      aud.PlaySound(2);
      Instantiate(spark, collision.contacts[0].point, Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.up, rb.position - collision.contacts[0].point), Vector3.forward));
    } else if (collision.gameObject.name != "Player") {
      aud.PlaySound((int)(Random.value * 2f));
      Instantiate(wallSpark, collision.contacts[0].point, Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.up, rb.position - collision.contacts[0].point), Vector3.forward));
    }
  }
  
  private void OnCollisionStay2D(Collision2D collision) {
    
    Debug.Log(collision.gameObject.tag);
    if (collision.gameObject.CompareTag("Hazard")) {
      Instantiate(spark, collision.contacts[0].point, Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.up, rb.position - collision.contacts[0].point), Vector3.forward));
    } else {
      Instantiate(wallSpark, collision.contacts[0].point, Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.up, rb.position - collision.contacts[0].point), Vector3.forward));
    }
  }
}
