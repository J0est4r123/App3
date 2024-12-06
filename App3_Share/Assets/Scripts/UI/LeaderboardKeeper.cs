using UnityEngine;

public class LeaderboardKeeper : MonoBehaviour
{
    private bool highScore = false;
    private int howHigh;
    

    public void AddScore (double _score, string _name){

        for(int i = 0; i < StaticData.scores.Length; i++) {
            print(_score.ToString() + ", " + _name);
            if(_score < StaticData.scores[i] && !highScore){
                highScore = true;
                howHigh = i;
                print(highScore.ToString() + ", " + howHigh);
            }
        }
        if (highScore){
            for(int i = StaticData.scores.Length - 1; i > 0 + howHigh; i--){
                StaticData.scores[i] = StaticData.scores[i-1];
                StaticData.names[i] = StaticData.names[i-1];
                PlayerPrefs.SetString("name" + i.ToString(), StaticData.names[i]);
                PlayerPrefs.SetString("score" + i.ToString(), StaticData.scores[i].ToString());
            }
            StaticData.scores[howHigh] = _score;
            StaticData.names[howHigh] = _name;
            PlayerPrefs.SetString(("name" + howHigh), StaticData.names[howHigh]);
            PlayerPrefs.SetString(("score" + howHigh), (StaticData.scores[howHigh].ToString())); 
        }
        highScore = false;
    }
}
