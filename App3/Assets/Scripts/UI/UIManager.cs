using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject pauseScreen;

    private void Awake(){
        pauseScreen.SetActive(false);
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pauseScreen.activeInHierarchy){
                PauseGame(false);
            }
            else{
                PauseGame(true);

            }
        }
    }
    private void PauseGame(bool status){
        pauseScreen.SetActive(status);
        if(status){
            Time.timeScale = 0;
        }
        else{
            Time.timeScale = 1;
        }
    }

    public void Play1(){
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
        StaticData.score = 0;
    }
    public void Play2(){
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
        StaticData.score = 0;
    }
    public void Play3(){
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
        StaticData.score = 0;
    }
    public void Play4(){
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
        StaticData.score = 0;
    }
    public void Play5(){
        SceneManager.LoadScene(7);
        Time.timeScale = 1;
        StaticData.score = 0;
    }
    public void Resume() {
        PauseGame(false);
    }
    public void LeaderBoard(){
        SceneManager.LoadScene(2);
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
    public void LevelSelect(){
        SceneManager.LoadScene(1);
    }
    public void Quit(){
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}