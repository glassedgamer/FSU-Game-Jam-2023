using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool on;
    // public bool startOn;

    [SerializeField] GameObject dayBG;
    [SerializeField] GameObject nightBG;

    void Start() {
        switchEnvironment();
    }

    void Update() {
        switchEnvironment();
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
}
