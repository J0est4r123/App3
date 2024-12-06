using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LeaderboardPrinter : MonoBehaviour
{

    [SerializeField] private string board;
    [SerializeField] private int pos;
    private TextMeshProUGUI txt;
    private TimeSpan formattedTime;

    private void Awake(){
        txt = GetComponent<TextMeshProUGUI>();
        if(board == "name"){
            txt.text = (pos+1).ToString() + "." + GetName(pos);
        }
        else if(board == "score"){
            formattedTime = TimeSpan.FromSeconds(GetScore(pos));
            if(GetScore(pos) < 600){
                txt.text = formattedTime.ToString().Substring(4, 7);
            }
            else if(GetScore(pos) < 3600){
                txt.text = formattedTime.ToString().Substring(3, 8);
            }
            else if(GetScore(pos) < 36000){
                txt.text = formattedTime.ToString().Substring(1, 10);
            }
            else{
                txt.text = formattedTime.ToString().Substring(0, formattedTime.ToString().Length-5);;
            }
        }
    }

    private string GetName(int _pos){
        print(_pos.ToString() + PlayerPrefs.GetString(("name"+_pos), "N/A") + "name"+_pos);
        return PlayerPrefs.GetString("name"+_pos.ToString(), "N/A");
    }
    private double GetScore(int _pos){
        return Convert.ToDouble(PlayerPrefs.GetString(("score"+_pos), "35999.99"));
    }
    
}
