using UnityEngine; 

public class Puddle : MonoBehaviour {
  
  private void Start() {
    Destroy(gameObject, 0.95f); 
  }
  
}