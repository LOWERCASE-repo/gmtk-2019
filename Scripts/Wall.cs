using UnityEngine;

public class Wall : MonoBehaviour {
  
  private enum State { Plain, Damp, Hot, Spiky, Golden };
  private State state;
  
  [SerializeField]
  private float minBounce;
  
  [Header("Prefabs")]
  [SerializeField]
  private PhysicsMaterial2D mat;
  
  private void OnCollisionEnter2D(Collision2D collision) {
    Vector2 vel = collision.rigidbody.velocity;
    if (vel.magnitude < minBounce) {
      collision.rigidbody.velocity = vel + vel.normalized * minBounce;
    }
    if (vel == Vector2.zero) {
      collision.rigidbody.velocity = transform.up * minBounce;
    }
  }
}
