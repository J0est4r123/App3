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
        StaticData.position.Clear();
        StaticData.level.Clear();
        StaticData.frameTimes.Clear();
        StaticData.scale.Clear();
        StaticData.inReplay = false;
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
        StaticData.score = 0;
    }
    public void Play2(){
        StaticData.position.Clear();
        StaticData.level.Clear();
        StaticData.frameTimes.Clear();
        StaticData.scale.Clear();
        StaticData.inReplay = false;
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
        StaticData.score = 0;
    }
    public void Play3(){
        StaticData.position.Clear();
        StaticData.level.Clear();
        StaticData.frameTimes.Clear();
        StaticData.scale.Clear();
        StaticData.inReplay = false;
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
        StaticData.score = 0;
    }
    public void Play4(){
        StaticData.position.Clear();
        StaticData.level.Clear();
        StaticData.frameTimes.Clear();
        StaticData.scale.Clear();
        StaticData.inReplay = false;
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
        StaticData.score = 0;
    }
    public void Play5(){
        StaticData.position.Clear();
        StaticData.level.Clear();
        StaticData.frameTimes.Clear();
        StaticData.scale.Clear();
        StaticData.inReplay = false;
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
        StaticData.replayFrame = StaticData.currentLevelReplayFrameStart;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
    public void LevelSelect(){
        SceneManager.LoadScene(1);
    }
    public void OpenCharacterSelect(){
        SceneManager.LoadScene(14);
    }
    public void Replay(){
        SceneManager.LoadScene(StaticData.level[0] + 6);
        StaticData.inReplay = true;
        StaticData.replayFrame = 0;
        StaticData.currentLevelReplayFrameStart = 0;
    }
    public void Quit(){
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
