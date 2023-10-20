using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndScreen : MonoBehaviour {
    
    GameObject levelChanger;

    [SerializeField] Text deathCounterText;

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        deathCounterText.text = "Deaths: " + GameManager.playerDeathCount.ToString();
    }

    public void Play() {
        GameManager.playerDeathCount = 0;
        levelChanger.GetComponent<LevelChanger>().LoadFirstLevel();
    }

    public void Quit() {
        Debug.Log("You quit");
        Application.Quit();
    }

    public void MainMenu() {
        GameManager.playerDeathCount = 0;
        FindObjectOfType<AudioManager>().Stop("Fly Me to the Moon");
        Destroy(FindObjectOfType<AudioManager>());
        levelChanger.GetComponent<LevelChanger>().LoadMainMenu();
    }
}
