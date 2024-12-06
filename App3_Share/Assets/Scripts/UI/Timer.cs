using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float currentTime{get; private set;}
    private TimeSpan formattedTime;
    private TextMeshProUGUI txt; 
    private void Awake(){
        currentTime = (float)StaticData.score;
        txt = GetComponent<TextMeshProUGUI>();
    }

    private void Update(){
        currentTime += Time.deltaTime;
        UpdateTimer();
    }

    private void UpdateTimer() {
        formattedTime = TimeSpan.FromSeconds(currentTime);
        if(currentTime < 600){
            txt.text = "Time: " + formattedTime.ToString().Substring(4, 7);
        }
        else if(currentTime < 3600){
            txt.text = "Time: " + formattedTime.ToString().Substring(3, 8);
        }
        else if(currentTime < 36000){
            txt.text = "Time: " + formattedTime.ToString().Substring(1, 10);
        }
        else{
            txt.text = "Time: " + formattedTime.ToString().Substring(0, formattedTime.ToString().Length-5);;
        }
    }
}
