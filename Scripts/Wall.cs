using UnityEngine;

public class Wall : MonoBehaviour {
  
  private enum State { Plain, Bouncy, Healing, Hot, Spiky };
  private State state;
  
  [SerializeField]
  private float speed;
  
  [Header("Prefabs")]
  [SerializeField]
  private PhysicsMaterial2D plain;
  [SerializeField]
  private PhysicsMaterial2D bouncy;
  
  private void OnCollisionEnter2D(Collision2D collision) {
  }
}
