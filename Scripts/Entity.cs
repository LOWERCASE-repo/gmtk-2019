using UnityEngine;

public abstract class Entity : MonoBehaviour {
  
  [SerializeField]
  protected float speed;
  [SerializeField]
  protected float acc;
  
  [Header("Components")]
  [SerializeField]
  protected Rigidbody2D rb;

  protected void Move(Vector2 pos) {
    rb.AddForce((pos - rb.position).normalized * acc);
  }

  protected void Rotate(Vector2 dir) {
    if (dir.Equals(Vector2.zero)) return;
    float ang = Vector2.SignedAngle(Vector2.up, dir);
    float pol = 1f - Mathf.Abs(ang) / 360f;
    rb.MoveRotation(Mathf.LerpAngle(rb.rotation, ang, pol));
  }

  protected virtual void Start() {
    rb.drag = acc / speed;
  }
}
