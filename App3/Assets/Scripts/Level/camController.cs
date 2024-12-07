using UnityEngine;
using UnityEngine.SceneManagement;

public class camController : MonoBehaviour
{
   [SerializeField] private float speed;
   [SerializeField] private GameObject speech;
   private float xPos;
   private float yPos;

   private Vector3 velocity = Vector3.zero;

   private void Update(){
      transform.position = Vector3.SmoothDamp(transform.position, new Vector3(xPos, yPos, transform.position.z), ref velocity, speed);
   }
   
   public void moveToNewRoom(Transform _newRoom){
    xPos = _newRoom.position.x;
    yPos = _newRoom.position.y;
    speech.SetActive(false);
   }
}
