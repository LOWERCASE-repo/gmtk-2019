using UnityEngine;

public class Ball : Entity {
  
  private void FixedUpdate() {
    rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed * 1.5f);
  }
}
