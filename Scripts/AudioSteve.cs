using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioSteve : MonoBehaviour {
  
  [SerializeField]
  private AudioClip[] sounds;
  [SerializeField]
  private AudioSource audio;
  
  [SerializeField]
  private Scene scene;
  
  private void Start() {
    Object.DontDestroyOnLoad(gameObject);
    // t(-_-t)
    SceneManager.LoadScene(2);
  }
  
  public void PlaySound(int index) {
    audio.PlayOneShot(sounds[index]);
  }
}
