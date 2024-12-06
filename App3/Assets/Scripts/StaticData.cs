using UnityEngine;
using System;

public class StaticData : MonoBehaviour
{
    public static double score;
    public static double[] scores = new double[10];
    public static new string[] names = new string[10];
    private void Awake(){
        if (PlayerPrefs.GetInt("init") == 1){
            for(int i = 0; i < scores.Length; i++) {
                scores[i] = Convert.ToDouble(PlayerPrefs.GetString(("score"+i), "35999.99"));
            }
            for(int i = 0; i < names.Length; i++) {
                names[i] = PlayerPrefs.GetString(("name"+i), "N/A");
            }
        }
        else{
            for(int i = 0; i < scores.Length; i++) {
                PlayerPrefs.SetString(("score"+ i), "35999.99");
                scores[i] = Convert.ToDouble(PlayerPrefs.GetString(("score"+i), "35999.99"));
            }
            for(int i = 0; i < names.Length; i++) {
                PlayerPrefs.SetString(("name"+ i), "N/A");
                names[i] = PlayerPrefs.GetString(("name"+i), "N/A");
            }
            PlayerPrefs.SetInt("init", 1);
        }
    }
}
