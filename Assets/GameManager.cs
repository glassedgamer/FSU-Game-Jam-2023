using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool on;
    // public bool startOn;

    public static int playerDeathCount = 0;

    [SerializeField] Text deathCounterText;

    [SerializeField] GameObject dayBG;
    [SerializeField] GameObject nightBG;

    void Start() {
        switchEnvironment();
        increaseDeathCounter();
    }

    void Update() {
        switchEnvironment();

        increaseDeathCounter();
    }

    public void OnOff() {
        on = !on;
    }

    void switchEnvironment() {
        if(on) {
            dayBG.SetActive(true);
            nightBG.SetActive(false);
        } else {
            dayBG.SetActive(false);
            nightBG.SetActive(true);
        }
    }

    public void increaseDeathCounter() {
        // Debug.Log(playerDeathCount);
        deathCounterText.text = "Deaths: " + playerDeathCount.ToString();
    }
}
