using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
  
  [Header("Components")]
  [SerializeField]
  private Text text;
  
  [Header("GameObjects")]
  [SerializeField]
  private Player player;
  
  private void Update() {
    // if (player.activeSelf) {
    // 
    // }
    text.text = "" + player.score;
  }
}
