using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
  
  [SerializeField]
  private Scene scene;
  
  private void Update() {
    if (Input.GetButton("Reset")) {
      SceneManager.LoadScene(1);
    }
  }
}
