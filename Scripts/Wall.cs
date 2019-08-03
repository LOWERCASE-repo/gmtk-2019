using UnityEngine;
using System.Collections.Generic;

public class Wall : MonoBehaviour {
  
  private enum State {  Hot, Golden, Spiky };
  private Dictionary<State, float> switches;
  private State state;
  private float switchChance;
  
  [Header("Components")]
  [SerializeField]
  private Animator animator;
  
  [Header("GameObjects")]
  [SerializeField]
  private Player player;
  
  private void SwitchState() {
    if (Random.value > switchChance) return;
    
  }
  
  private void Start() {
    switchCount = 0;
    switchChance = 0.3f;
  }
  
  private int switchCount;
  private void Update() {
    if (player.score > (switchCount + 1) * 20) {
      SwitchState();
      switchCount++;
    }
  }
}
