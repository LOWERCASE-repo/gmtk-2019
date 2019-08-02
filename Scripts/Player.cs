using UnityEngine;

public class Player : Entity {
  
  private Vector2 mousePos;
  
  protected override void Start() {
    base.Start();
  }
  
  protected void FixedUpdate() {
    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Move(mousePos);
    Rotate(rb.velocity);
  }
}
