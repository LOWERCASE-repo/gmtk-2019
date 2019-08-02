using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
  
  // private float targetZoom;
  private Vector2 targetPos;

  private Vector2 joltDir;

  [Header("Components")]
  [SerializeField]
  private Camera cam;
  [SerializeField]
  private Animator animator;
  
  [Header("GameObjects")]
  [SerializeField]
  private Rigidbody2D player;
  
  [Header("Debug")]
  [SerializeField]
  private float joltMag;
  public Vector2 mousePos;

  public void Jolt(Vector2 dir) {
    joltDir = dir;
    animator.SetTrigger("Jolt");
  }
  
  private void FixedUpdate() {
    mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
    targetPos = Vector2.Lerp(player.position, mousePos, 0f);
    transform.position = (Vector3)(targetPos + joltDir * joltMag) + new Vector3(0f, 0f, -10f);
  }
}
