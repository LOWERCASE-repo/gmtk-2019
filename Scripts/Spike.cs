using UnityEngine;
using System.Collections;

public class Spike : Entity {
  
  protected override void Start() {
    base.Start();
  }
  
  protected void FixedUpdate() {
    Move(rb.position + rb.velocity + Random.insideUnitCircle * 0.2f);
  }
}
