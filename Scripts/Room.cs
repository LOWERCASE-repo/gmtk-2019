using UnityEngine;

public class Room : MonoBehaviour {
  
  [Header("GameObjects")]
  [SerializeField]
  private Player player;
  
  [Header("Components")]
  [SerializeField]
  private Animator animator;
  
  private void Start() {
    phase = 0;
  }
  
  private int phase;
  private void Update() {
    switch (phase) {
      case 0:
      if (player.score >= 20) {
        animator.SetBool("Moving", true);
        phase++;
      }
      break;
      
      case 1:
      if (player.score >= 40) {
        animator.SetBool("Moving", false);
        animator.SetBool("Spinning", true);
        phase++;
      }
      break;
      
      case 2:
      if (player.score >= 60) {
        animator.SetBool("Moving", true);
        animator.SetBool("Spinning", true);
        phase++;
      }
      break;
    }
  }
}
