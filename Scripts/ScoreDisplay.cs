using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
  
  [Header("Components")]
  [SerializeField]
  private Text smallText;
  [SerializeField]
  private Text bigText;
  [SerializeField]
  private GameObject smallScoreName;
  [SerializeField]
  private GameObject bigScoreName;
  [SerializeField]
  private GameObject clickToRestart;
  
  [Header("GameObjects")]
  [SerializeField]
  private Player player;
  [SerializeField]
  private Animator filter;
  private string score;
  
  private void Update() {
    score = "" + player.score;
    if (player.gameObject.activeSelf) {
      smallText.text = score;
      
    } else {
      EndGame();
      // gameObject.SetActive(false);
    }
  }
  
  private void EndGame() {
    filter.SetTrigger("Fade");
    bigText.text = score;
    smallText.text = "";
    smallScoreName.SetActive(false);
    bigScoreName.SetActive(true);
    clickToRestart.SetActive(true);
  }
}
