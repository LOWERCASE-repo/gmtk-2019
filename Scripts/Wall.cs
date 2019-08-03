using UnityEngine;
using System.Collections.Generic;

public class Wall : MonoBehaviour {
  
  private enum State {  Hot, Spiky };
  private State state;
  
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
      animator.SetBool("Flaming", !animator.GetBool("Flaming"));
      switchChance = 0f;
    }
  }
  
  private void Start() {
    SwitchState();
  }
  
  private int prevScore;
  private void Update() {
    if (player.score > prevScore) {
      float switchBonus = player.score - prevScore;
      if (animator.GetBool("Flaming")) {
        switchBonus /= 200f;
      } else {
        switchBonus /= 800f;
      }
      switchChance += switchBonus;
      prevScore = player.score;
      SwitchState();
    }
  }
}
