using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Safer way to check tags
        {
            if(SceneManager.GetActiveScene().buildIndex < 9){
                StaticData.money += 1; // Increment player money
                PlayerPrefs.SetInt("money", StaticData.money); // Save to PlayerPrefs
                Debug.Log("Coin collected! Total money: " + StaticData.money);
            }
            Destroy(gameObject); // Remove coin from the scene
        }
    }
}