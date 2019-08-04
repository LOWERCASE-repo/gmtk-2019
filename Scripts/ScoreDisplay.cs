using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
  
  [Header("Components")]
  [SerializeField]
  private Text smallText;
  [SerializeField]
  private Text bigText;
  [SerializeField]
  private GameObject scoreName;
  
  [Header("GameObjects")]
  [SerializeField]
  private Player player;
  [SerializeField]
  private SpriteRenderer filter;
  
  
  
  private void Update() {
    string score = "" + player.score;
    smallText.text = score;
    bigText.text = score;
  }
}
