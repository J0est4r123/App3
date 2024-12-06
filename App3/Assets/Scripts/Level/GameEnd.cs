using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private ScoreHolder scoreHolder;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            StaticData.score = scoreHolder.GetScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
   }
}
