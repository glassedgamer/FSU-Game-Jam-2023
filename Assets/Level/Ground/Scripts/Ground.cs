using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
    GameObject gameManager;
    [SerializeField] GameObject insideCollider;

    // References to things on the ground object
    SpriteRenderer groundRenderer;
    [SerializeField] BoxCollider2D collider;

    // Bools for turning on and off environment
    bool onn;
    [SerializeField] bool startOnn;

    // Different colors for each ground stae
    [SerializeField] Color startOnColorDay;
    [SerializeField] Color startOnColorNight;
    [SerializeField] Color startOffColorDay;
    [SerializeField] Color startOffColorNight;


    void Start() {
        // Setting variables
        gameManager = GameObject.FindWithTag("GameManager");
        groundRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        onn = gameManager.GetComponent<GameManager>().on;
        collider = GetComponent<BoxCollider2D>();

        // Starts game by changing color
        changeGround();
    }

    void Update() {
        // Constantly updating on variable from Game Manager
        onn = gameManager.GetComponent<GameManager>().on;
        changeGround();
        // startOnn = gameManager.GetComponent<GameManager>().startOn;
    }

    void changeGround() {
        // Sets color of ground based on bools
        if(startOnn && onn) {
            // Color for when ground is on and its day
            if(insideCollider != null)
                insideCollider.SetActive(true);
                
            collider.enabled = true;
            groundRenderer.material.color = startOnColorDay;
        } else if(startOnn && onn == false) {
            // Color for when ground is off and its night
            if(insideCollider != null)
                insideCollider.SetActive(false);
                
            collider.enabled = false;
            groundRenderer.material.color = startOffColorNight;
        } else if(startOnn == false && onn) {
            // Color for when ground is off and its day
            if(insideCollider != null)
                insideCollider.SetActive(false);

            collider.enabled = false;
            groundRenderer.material.color = startOffColorDay;
        } else if(startOnn == false && onn == false) {
            // Color for when ground is on and its night
            if(insideCollider != null)
                insideCollider.SetActive(true);

            collider.enabled = true;
            groundRenderer.material.color = startOnColorNight;
        }
    }
}
