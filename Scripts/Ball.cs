using UnityEngine;

public class Ball : Entity {
  
  // passive gain 1ps
  // bounce gives 5
  // two bounces gives 15
  // three gives 30
  
  // gold walls double points
  // spiky ball smash gives 10 + 10 * ricochets
  
  // walls chance of change every 20 points
  // rooms change at 100, 200, 400
  
  // wall chance of change increases with points
  
  [SerializeField]
  private float catchWindow;
  private float thrownTime;
  
  [SerializeField]
  private Player player;
  
  private int ricoCount;
  private int smashCount;
  private bool golden;
  private bool flaming;
  
  private int GetScore() {
    int score = (int)Mathf.Round(Mathf.Pow(ricoCount, 1.5f)) * 5;
    score += ricoCount * smashCount * 10;
    if (golden) score *= 2;
    
    ricoCount = 0;
    smashCount = 0;
    golden = false;
    flaming = false;
    
    return score;
  }
  
  private void FixedUpdate() {
    rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed * 1.5f);
  }
  
  private void OnTriggerEnter2D() {
    if (!flaming) {
      player.score += GetScore();
    } else {
      Debug.Log("player burnt");
    }
  }
  
  private void OnCollisionEnter2D() {
    ricoCount += 1;
  }
}
