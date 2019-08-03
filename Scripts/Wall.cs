using UnityEngine;

public class Wall : MonoBehaviour {
  
  private enum State { Default, Hot, Bouncy, Portal };
  private State state;
  
  [SerializeField]
  private float speed;
  
  [Header("Prefabs")]
  [SerializeField]
  private PhysicsMaterial2D plain;
  [SerializeField]
  private PhysicsMaterial2D bouncy;
  
  [Header("GameObjects")]
  [SerializeField]
  private Wall opposite;
  
  private bool hot;
  
  
  
  private void OnCollisionEnter2D(Collision2D collision) {
  }
}
