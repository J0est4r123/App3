using TMPro;
using UnityEngine;

public class InputGrabber : MonoBehaviour
{
    [SerializeField] private string inputText;
    [SerializeField] private SelectionArrow selectionArrow;
    [SerializeField] private bool submitted;
    private LeaderboardKeeper lbKeeper;
    private void Awake(){
        lbKeeper = GetComponent<LeaderboardKeeper>();
        submitted = false;
    }
    public void GetFromInputField(string input){
        if(input.Length >= 3 && input.Length <= 15 && !submitted){
            inputText = input;
            lbKeeper.AddScore(StaticData.score, inputText);
            submitted = true;
        }
    }

    public void DisableArrow(string input){
        selectionArrow.enabled = false;
    }

    public void EnableArrow(string input){
        selectionArrow.enabled = true;
    }
}
