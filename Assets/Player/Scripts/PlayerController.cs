using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // [SerializeField] GameObject beanGFX;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer playerRenderer;
    [SerializeField] CapsuleCollider2D collider;
    [SerializeField] AudioSource walkingSound;

    GameObject levelChanger;
    GameObject gameManager;

    // [SerializeField] Transform respawnPoint;

    [SerializeField] Color playerDay;
    [SerializeField] Color playerNight;

    Vector2 movement;
    // Vector3 rotation;

    // [SerializeField] float respawnTimeValue;
    
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
        // levelChanger = GameObject.FindWithTag("LevelChanger");
        
        // rotation = new Vector3(0f, 0f, 0f);

        changeColor();
    }

    void Update() {
        onnn = gameManager.GetComponent<GameManager>().on;
        changeColor();
        
        movement = new Vector2(inputX * moveSpeed, rb.velocity.y);
        
        rb.velocity = movement;
        
        if(movement != Vector2.zero && isGrounded) {
            animator.SetBool("isWalking", true);
            walkingSound.enabled = true;
            // FindObjectOfType<AudioManager>().Play("Walking");
        } else if(movement == Vector2.zero){
            animator.SetBool("isWalking", false);
            walkingSound.enabled = false;
            // FindObjectOfType<AudioManager>().Stop("Walking");
        } 

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
            walkingSound.enabled = false;
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            FindObjectOfType<AudioManager>().Play("Jump");
        }
    }

    public void OnOffThing(InputAction.CallbackContext context) {
        if(context.started) {
            gameManager.GetComponent<GameManager>().OnOff();
            FindObjectOfType<AudioManager>().Play("OnOff");
        }
    }

    // void respawn() {
    //     collider.enabled = true;
    //     this.gameObject.transform.position = respawnPoint.position;
    //     beanGFX.gameObject.transform.GetChild(0).eulerAngles = rotation;
    //     beanGFX.SetActive(true);
    //     Debug.Log("Fortnite");
    // }

    void changeColor() {
        if(onnn) {
            playerRenderer.material.color = playerDay;
        } else {
            playerRenderer.material.color = playerNight;
        }
    }

    // void OnCollisionEnter2D(Collision2D col) {
    //     if(col.gameObject.tag == "InsideCollider") {
    //         Debug.Log("lol");
    //         beanGFX.SetActive(false);
    //         collider.enabled = false;
    //         Invoke("respawn", respawnTimeValue);
    //     } else if(col.gameObject.tag == "Star") {
    //         levelChanger.GetComponent<LevelChanger>().LoadNextLevel();
    //         Destroy(col.gameObject);
    //     }
    // }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

}
