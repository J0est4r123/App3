using UnityEngine;

public class spikes : MonoBehaviour
{
    [SerializeField] private float dmg;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            collision.GetComponent<health>().takeDmg(dmg);
        }
    }
}
