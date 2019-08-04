using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {
  
  [Header("GameObjects")]
  [SerializeField]
  private Player player;
  
  [Header("Components")]
  [SerializeField]
  private Animator animator;
  
  private IEnumerator ChangePhases() {
    yield return new WaitForSecondsRealtime(10f);
    animator.SetBool("Moving", true);
    yield return new WaitForSecondsRealtime(17.5f);
    animator.SetBool("Moving", false);
    yield return new WaitForSecondsRealtime(2.5f);
    animator.SetBool("Spinning", true);
    yield return new WaitForSecondsRealtime(20f);
    animator.SetBool("Moving", true);
  }
  
  private void Start() {
    StartCoroutine(ChangePhases());
  }
}
