using UnityEngine;

public class respawning : MonoBehaviour
{
    private Transform currentCheckpoint;
    private health playerHealth;

    private void Awake(){
        playerHealth = GetComponent<health>();
    }

    public void Respawn(){
        transform.position = currentCheckpoint.position;
        playerHealth.respawn();
        Camera.main.GetComponent<camController>().moveToNewRoom(currentCheckpoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.transform.tag == "Checkpoint"){
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
