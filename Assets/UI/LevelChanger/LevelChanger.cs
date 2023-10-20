using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour {

    AudioSource lobbyMusic;

    public Animator anim;

    public float transitionTime = 2f;

    void Start() {
        
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMainMenu() {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadFirstLevel() {
        StartCoroutine(LoadLevel(1));
    }

    public IEnumerator LoadLevel(int levelIndex) {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
