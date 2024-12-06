using System;
using UnityEngine;
using UnityEngine.UI;

public class flashController : MonoBehaviour
{
    [SerializeField]private float flashTime;
    [SerializeField]private Transform cam;
    private AudioSource source;
    private AudioClip clip;
    private float currentFlashTime = 0;
    private float betweenFlashes;
    private CanvasGroup image;
    private void Awake(){
    image = GetComponent<CanvasGroup>();
    source = GetComponent<AudioSource>();
    betweenFlashes = UnityEngine.Random.Range(2f, 5f);
    image.alpha = 0;
   }
    private void Update(){
        betweenFlashes -= Time.deltaTime;
        if (betweenFlashes <=0 && currentFlashTime <=0){
            currentFlashTime = flashTime;
            source.Play();
        }
        if(currentFlashTime > 0){
            cam.position = new Vector3(cam.position.x + UnityEngine.Random.Range(-0.02f,0.02f), cam.position.y + UnityEngine.Random.Range(-0.02f,0.02f), cam.position.z);
            image.alpha = currentFlashTime/flashTime;
            currentFlashTime -= Time.deltaTime;
            if(currentFlashTime <=0){
                betweenFlashes = UnityEngine.Random.Range(2f, 5f);
            }
        }
                    
    }
}
