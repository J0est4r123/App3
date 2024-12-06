using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
   [SerializeField] private Timer timer;

   public double GetScore(){
    return timer.currentTime;
   }
}
