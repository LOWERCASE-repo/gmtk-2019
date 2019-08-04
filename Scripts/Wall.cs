using UnityEngine;
using System.Collections.Generic;

public class Wall : MonoBehaviour {
  
  [SerializeField]
  private float switchChance;
  
  [Header("Components")]
  [SerializeField]
  private Animator animator;
  
  [Header("GameObjects")]
  [SerializeField]
  private Player player;
  
  private void SwitchState() {
    if (Random.value < switchChance) {
      bool flaming = animator.GetBool("Flaming");
      animator.SetBool("Flaming", !flaming);
      switchChance = 0f;
    }
  }
  
  private void Start() {
    SwitchState();
  }
  
  private int prevScore;
  private void Update() {
    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Flaming")) {
      gameObject.tag = "Hazard";
    } else {
      gameObject.tag = "Untagged";
    } // not sorry
    if (player.score > prevScore) {
      float switchBonus = player.score - prevScore;
      if (animator.GetBool("Flaming")) {
        switchBonus /= 100f;
      } else {
        switchBonus /= 500f;
      }
      switchChance += switchBonus;
      prevScore = player.score;
      SwitchState();
    }
  }
}
