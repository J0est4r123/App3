using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private ScoreHolder scoreHolder;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            StaticData.score = scoreHolder.GetScore();
            StaticData.UnlockCharacter(SceneManager.GetActiveScene().buildIndex - 3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
   }
}
