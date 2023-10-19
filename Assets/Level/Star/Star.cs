using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    GameObject gameManager;

    // References to things on the ground object
    [SerializeField] SpriteRenderer starRenderer;

    // Bools for turning on and off environment
    bool onn;

    // Different colors for each ground stae
    [SerializeField] Color dayColor;
    [SerializeField] Color nightColor;

    void Start() {
        // Setting variables
        gameManager = GameObject.FindWithTag("GameManager");
        onn = gameManager.GetComponent<GameManager>().on;

        // Starts game by changing color
        changeColor();
    }

    void Update() {
        // Constantly updating on variable from Game Manager
        onn = gameManager.GetComponent<GameManager>().on;
        changeColor();
        // startOnn = gameManager.GetComponent<GameManager>().startOn;
    }

    void changeColor() {
        // Sets color of ground based on bools
        if(onn) {
            // Color for when ground is on and its day
            starRenderer.material.color = dayColor;
        } else if(onn == false) {
            // Color for when ground is off and its night
            starRenderer.material.color = nightColor;
        }
    }
}