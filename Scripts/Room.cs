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
      if (player.score >= 100) {
        if (Random.value < 0.5f) {
          animator.SetBool("Moving", true);
        } else {
          animator.SetBool("Spinning", true);
        }
        phase++;
      }
      break;
      
      case 1:
      if (player.score >= 200) {
        animator.SetBool("Moving", !animator.GetBool("Moving"));
        animator.SetBool("Spinning", !animator.GetBool("Spinning"));
        phase++;
      }
      break;
      
      case 2:
      if (player.score >= 300) {
        animator.SetBool("Moving", true);
        animator.SetBool("Spinning", true);
        phase++;
      }
      break;
    }
  }
}
