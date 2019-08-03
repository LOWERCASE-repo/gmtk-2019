using UnityEngine;

public class Room : MonoBehaviour {
  
  private enum State { Plain, Moving, Spinning };
  private State[] states;
  
  [SerializeField]
  private float speed;
  [SerializeField]
  private float speedButAgain;
  
  [Header("GameObjects")]
  [SerializeField]
  private Wall[] walls;
  
  private void FixedUpdate() {
    // transform.RotateAround(transform.position, Vector3.forward, speed * speedButAgain);
    transform.rotation = Quaternion.AngleAxis(speed * speedButAgain, Vector3.forward);
  }
}
