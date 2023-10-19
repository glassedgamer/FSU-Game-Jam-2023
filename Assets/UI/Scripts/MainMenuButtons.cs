using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    GameObject levelChanger;

    public GameObject mainMenu;
    public GameObject credits;

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");
        mainMenu.SetActive(true);
    }

    public void Play() {
        levelChanger.GetComponent<LevelChanger>().LoadFirstLevel();
    }

    public void SwitchToMainMenu() {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void SwitchToCredits() {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void Quit() {
        Debug.Log("You quit");
        Application.Quit();
    }

}
