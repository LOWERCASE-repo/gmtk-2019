using UnityEngine;
using System.Collections;

public class Player : Entity {
  
  private Vector2 mousePos;
  
  [SerializeField]
  private float scoreDelay;
  public int score;
  
  [Header("Components")]
  [SerializeField]
  private Animator animator;
  [SerializeField]
  private Transform eyes;
  private Vector2 eyeCentroid;
  [SerializeField]
  private GameObject puddle;
  [SerializeField]
  private Transform room;
  [SerializeField]
  private float trailRate;
  [SerializeField]
  private GameObject death;
  
  private IEnumerator GrowScore() {
    yield return new WaitForSecondsRealtime(scoreDelay);
    score++;
    StartCoroutine(GrowScore());
  }
  
  private IEnumerator TrailSlime() {
    yield return new WaitForSecondsRealtime(trailRate);
    GameObject temp = Instantiate(puddle, transform.position, Quaternion.identity, room);
    temp.transform.localScale *= 0.5f + Random.value;
    temp.transform.localScale = (Vector2)temp.transform.localScale;
    StartCoroutine(TrailSlime());
  }
  
  private IEnumerator DelayDisable(float time) {
    yield return new WaitForSecondsRealtime(time);
    Time.timeScale = 0f;
    Time.fixedDeltaTime = 200f;
    gameObject.SetActive(false);
  }
  
  private IEnumerator DelaySpawn(float time) {
    yield return new WaitForSecondsRealtime(time);
    Instantiate(death, transform.position, Quaternion.identity);
  }
  
  protected override void Start() {
    base.Start();
    Time.timeScale = 1;
    Time.fixedDeltaTime = 0.02f;
    score = 0;
    StartCoroutine(GrowScore());
    StartCoroutine(TrailSlime());
    eyeCentroid = new Vector2(0.14f, 0.1f);
  }
  
  protected void FixedUpdate() {
    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
      Move(mousePos);
    }
    eyes.localPosition = eyeCentroid + Vector2.ClampMagnitude(mousePos - rb.position, 1f) * 0.3f;
  }
  
  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.name == "Spike") {
      animator.SetTrigger("Crushed");
      StartCoroutine(DelayDisable(1f));
    } else if (collision.gameObject.CompareTag("Hazard")) {
      animator.SetTrigger("Burnt");
      StartCoroutine(DelayDisable(1.49f));
      StartCoroutine(DelaySpawn(0.5f));
    }
  }
  
  private void OnCollisionStay2D(Collision2D collision) {
    OnCollisionEnter2D(collision);
  }
}
