using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    GameObject levelChanger;

    public GameObject mainMenu;
    public GameObject credits;

    AudioSource lobbyMusic;

    // [SerializeField] bool playMusic;

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");
        mainMenu.SetActive(true);

        lobbyMusic = GameObject.FindWithTag("LobbyMusic").GetComponent<AudioSource>();

        lobbyMusic.enabled = true;
        
        // if(playMusic)
        //     FindObjectOfType<AudioManager>().Play("Jaz(yy)z");
    }

    public void Play() {
        // FindObjectOfType<AudioManager>().Stop("Jaz(yy)z");
        // FindObjectOfType<AudioManager>().mainMenu = false;
        lobbyMusic.enabled = false;
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
