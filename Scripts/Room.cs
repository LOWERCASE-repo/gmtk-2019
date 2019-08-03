using UnityEngine;
using System;
using System.Collections.Generic;

public class Room : MonoBehaviour {
  
  private enum State { Moving, Spinning, Windy };
  private HashSet<State> inactive;
  private HashSet<State> active;
  
  [SerializeField]
  private float speed;
  [SerializeField]
  private float speedButAgain;
  
  [Header("GameObjects")]
  [SerializeField]
  private Wall[] walls;
  [SerializeField]
  private Player player;
  
  [Header("Components")]
  [SerializeField]
  private Animator animator;
  
  private void AddState() {
    int choice = (int)(UnityEngine.Random.value * inactive.Count - Mathf.Epsilon);
    int i = 0;
    foreach (State state in inactive) {
      if (i == choice) {
        active.Add(state);
        inactive.Remove(state);
        break;
      }
      i++;
    }
    if (active.Contains(State.Spinning)) animator.SetBool("Spinning", true);
    if (active.Contains(State.Moving)) animator.SetBool("Moving", true);
  }
  
  private void Start() {
    var states = Enum.GetValues(typeof(State));
    inactive = new HashSet<State>();
    foreach (State state in states) {
      inactive.Add(state);
    }
    active = new HashSet<State>();
  }
  
  private void FixedUpdate() {
    transform.rotation = Quaternion.AngleAxis(speed * speedButAgain, Vector3.forward);
  }
  
  private void Update() {
    if (player.score > (active.Count + 1) * 10) {
      AddState();
    }
  }
}
