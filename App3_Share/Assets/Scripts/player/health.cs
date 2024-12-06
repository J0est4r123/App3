using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private Animator animator;
    private Rigidbody2D body;
    public float currentHealth{get; private set;}
    private bool dead;

    private void Awake () {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    public void takeDmg (float _damage) {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0){
            // Placeholder if I gave more than 1 health
        }
        else{
            if(!dead){
                Time.timeScale = 0.5f;
                Camera.main.GetComponent<camController>().moveToNewRoom(transform);
                Camera.main.GetComponent<Camera>().orthographicSize = 3;
                body.velocity = Vector2.zero;
                GetComponent<playerMovement>().enabled = false;
                animator.SetBool("grounded", true);
                animator.SetTrigger("die");
                dead = true;
            }
            
        }
    }

    public void respawn () {
        Time.timeScale = 1f;
        Camera.main.GetComponent<Camera>().orthographicSize = 5;
        dead = false;
        currentHealth = startingHealth;
        animator.ResetTrigger("die");
        animator.Play("idle");
        GetComponent<playerMovement>().enabled = true;
    }
}
