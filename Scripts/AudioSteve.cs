using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioSteve : MonoBehaviour {
  
  [SerializeField]
  private AudioClip[] sounds;
  [SerializeField]
  private AudioSource audio;
  
  private void Start() {
    Object.DontDestroyOnLoad(gameObject);
  }
  
  public void PlaySound(int index) {
    audio.PlayOneShot(sounds[index]);
  }
}
