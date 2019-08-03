using UnityEngine;

public abstract class Entity : MonoBehaviour {
  
  [SerializeField]
  protected float speed;
  [SerializeField]
  protected float acc;
  
  [Header("Components")]
  [SerializeField]
  public Rigidbody2D rb;
  
  [Header("GameObjects")]
  [SerializeField]
  private MainCamera cam;

  protected void Move(Vector2 pos) {
    rb.AddForce((pos - rb.position).normalized * acc);
  }

  protected void Rotate(Vector2 dir) {
    if (dir.Equals(Vector2.zero)) return;
    float ang = Vector2.SignedAngle(Vector2.up, dir);
    rb.rotation = ang;
  }

  protected virtual void Start() {
    rb.drag = acc / speed;
  }
}
