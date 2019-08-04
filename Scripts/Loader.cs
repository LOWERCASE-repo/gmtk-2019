using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {
  
  [SerializeField]
  private GameObject player;
  
  private void Update() {
    if (!player.activeSelf && Input.GetButton("Reset")) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
}
