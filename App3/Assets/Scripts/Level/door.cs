using UnityEngine;

public class door : MonoBehaviour
{
   [SerializeField] private Transform previousRoom;
   [SerializeField] private Transform nextRoom;
   [SerializeField] private camController cam;

   private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            if(collision.transform.position.x<transform.position.x){
                cam.moveToNewRoom(nextRoom);
            }
            else{
                cam.moveToNewRoom(previousRoom);
            }
        }
   }
   
}
