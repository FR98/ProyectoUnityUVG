﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public GameObject winTxt;
    public GameObject loseTxt;
    private bool ganaAI = false;
    private bool ganaPlayer = false;
    float secondsCounter = 0;
    float secondsToCount = 10;
    private bool tiempo = false;

    // Start is called before the first frame update
    void Start()
    {
        winTxt.SetActive(false);
        loseTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (secondsCounter >= secondsToCount) {
            secondsCounter = 0;
            tiempo = true;
        }
    }

    private void OnTriggerStay(Collider collider) {
        if (!ganaAI && !ganaPlayer) {
            if(collider.gameObject.tag == "Player") {
                win();
            } else if (collider.gameObject.tag == "AI") {
                lose();
            }
        }

    }

    void win() {
        winTxt.SetActive(true);
        ganaPlayer = true;
        // Hacer una pausa
        secondsCounter += Time.deltaTime;
        if (tiempo) {
            changeScene("Worldd");
        }
    }

    void lose() {
        loseTxt.SetActive(true);
        ganaAI = true;
        // Hacer una pausa
        secondsCounter += Time.deltaTime;
        if (tiempo) {
            changeScene("SampleScene");
        }
    }

    public void changeScene(string newScene) {
        SceneManager.LoadScene(newScene);
    }
}
