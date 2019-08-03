using UnityEngine;
using System.Collections.Generic;

public class Wall : MonoBehaviour {
  
  private enum State { Plain, Golden, Hot, Spiky };
  private Dictionary<State, float> switches;
  private State state;
  
  [SerializeField]
  private float minBounce;
  
  [Header("Components")]
  [SerializeField]
  private Animator animator;
  
  [Header("Prefabs")]
  [SerializeField]
  private PhysicsMaterial2D mat;
  
  [Header("GameObjects")]
  [SerializeField]
  private Player player;
  
  private void OnCollisionEnter2D(Collision2D collision) {
    Vector2 vel = collision.rigidbody.velocity;
    if (vel.magnitude < minBounce) {
      collision.rigidbody.velocity = vel.normalized * minBounce;
    }
    if (vel == Vector2.zero) {
      collision.rigidbody.velocity = (Vector2)transform.up * minBounce;
    }
    
    // if ()
  }
}
