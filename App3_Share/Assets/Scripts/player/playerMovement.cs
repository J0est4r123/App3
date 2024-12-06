using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
   [SerializeField] private float speed;
   [SerializeField] private float wind;
   [SerializeField] private float jumpPower;
   [SerializeField] private float coyoteTime;
   [SerializeField] private int extraJumps;
   [SerializeField] private int wallJumpX;
   [SerializeField] private int wallJumpY;
   [SerializeField] private LayerMask groundLayer;
   [SerializeField] private LayerMask wallLayer;

   // Grabbing references
   private Rigidbody2D body;
   private Animator animator;
   private BoxCollider2D boxCollider;

   private float horizontalInput;
   private float coyoteCounter;
   private int jumpCounter;
   private void Awake(){
    body = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    boxCollider = GetComponent<BoxCollider2D>();
   }
   
   private void Update() {

    horizontalInput = Input.GetAxis("Horizontal");
    
    // Flip facing direction
    if(horizontalInput > 0.01f){
        transform.localScale = new Vector3(1, 1, 1);
    }
    else if(horizontalInput < -0.01f){
        transform.localScale = new Vector3(-1, 1, 1);
    }

    animator.SetBool("run", horizontalInput != 0);
    animator.SetBool("grounded", isGrounded());

    if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
        jump();
    }

    if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && body.velocity.y>0){
        body.velocity = new Vector2(body.velocity.x, body.velocity.y/2);
    }

    if(onWall()){
        body.gravityScale = 0;
        body.velocity = Vector2.zero;
    }
    else{
        body.gravityScale = 3;
        if(SceneManager.GetActiveScene().buildIndex==6){
            if(body.velocity.x >= 10 || body.velocity.x <= -10){

            }
            else{
                body.AddForce(new Vector2(horizontalInput*speed + wind, 0));
            }
        }
        else{
            body.velocity = new Vector2(horizontalInput*speed + wind, body.velocity.y);
        }

        if(isGrounded()){
            coyoteCounter = coyoteTime;
            jumpCounter = extraJumps;
        }
        else{
            coyoteCounter -= Time.deltaTime;
        }
    }
   }

    private void jump(){
        if(coyoteCounter <= 0 && !onWall() && jumpCounter <= 0){
            return;
        }
        
        if (onWall()){
            wallJump();
        }
        else{
            if(isGrounded()){
                body.velocity = new Vector2(body.velocity.x, jumpPower);
            }
            else{
                if(coyoteCounter > 0){
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                }
                else{
                    if(jumpCounter > 0){
                        body.velocity = new Vector2(body.velocity.x, jumpPower);
                        jumpCounter--;
                    }
                }
            }
            coyoteCounter = 0;
        }
   }

    private void wallJump(){
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x)*wallJumpX, wallJumpY));
    }
   
   private bool isGrounded(){

    RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
    return raycastHit.collider != null;
   }

   private bool onWall(){

    RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
    return raycastHit.collider != null;
   }
}