using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] Rigidbody2D rb;
    //[SerializeField] Animator animator;
    [SerializeField] SpriteRenderer playerRenderer;
    GameObject gameManager;
    [SerializeField] Transform respawnPoint;

    [SerializeField] Color playerDay;
    [SerializeField] Color playerNight;

    Vector2 movement;

    [SerializeField] float respawnTimeValue;
    
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 2f;

    private float inputX;

    bool isGrounded;
    bool facingRight = true;
    bool onnn;

    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    void Start() {
        gameManager = GameObject.FindWithTag("GameManager");
        // playerRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        onnn = gameManager.GetComponent<GameManager>().on;

        changeColor();
    }

    void Update() {
        onnn = gameManager.GetComponent<GameManager>().on;
        changeColor();
        
        movement = new Vector2(inputX * moveSpeed, rb.velocity.y);
        
        rb.velocity = movement;
        
        /*if(movement != Vector2.zero && isGrounded) {
            animator.SetBool("isWalking", true);
        } else if(movement == Vector2.zero){
            animator.SetBool("isWalking", false);
        } */

        if(facingRight == false && inputX > 0) {
            Flip();
        } else if(facingRight == true && inputX < 0) {
            Flip();
        }

    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
    
    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Move(InputAction.CallbackContext context) {
        inputX = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context) {
        if(isGrounded) {
            //animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void OnOffThing(InputAction.CallbackContext context) {
        gameManager.GetComponent<GameManager>().OnOff();
    }

    void respawn() {
        this.gameObject.transform.position = respawnPoint.position;
        this.gameObject.SetActive(true);
    }

    void changeColor() {
        if(onnn) {
            playerRenderer.material.color = playerDay;
        } else {
            playerRenderer.material.color = playerNight;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "InsideCollider") {
            Debug.Log("lol");
            this.gameObject.SetActive(false);
            Invoke("respawn", respawnTimeValue);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

}
