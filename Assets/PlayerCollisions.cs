using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    [SerializeField] SpriteRenderer playerRenderer;
    [SerializeField] CapsuleCollider2D collider;

    [SerializeField] Transform respawnPoint;

    GameObject levelChanger;
    GameObject gameManager;

    [SerializeField] GameObject beanGFX;

    [SerializeField] float respawnTimeValue;
    Vector3 rotation;

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");
        gameManager = GameObject.FindWithTag("GameManager");

        rotation = new Vector3(0f, 0f, 0f);
    }

    void respawn() {
        collider.enabled = true;
        this.gameObject.transform.position = respawnPoint.position;
        beanGFX.gameObject.transform.GetChild(0).eulerAngles = rotation;
        beanGFX.SetActive(true);
        Debug.Log("Fortnite");
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "InsideCollider") {
            Debug.Log("lol");
            GameManager.playerDeathCount += 1;
            beanGFX.SetActive(false);
            collider.enabled = false;
            Invoke("respawn", respawnTimeValue);
        } else if(col.gameObject.tag == "Star") {
            levelChanger.GetComponent<LevelChanger>().LoadNextLevel();
            Destroy(col.gameObject);
        }
    }

}
