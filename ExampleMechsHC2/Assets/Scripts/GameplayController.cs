using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

    private Text countdownText;
    public int countdown = 100;

    void Awake() {
        countdownText = GameObject.Find("Countdown").GetComponent<Text>();
    }

    void Start() {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown() {

        yield return new WaitForSeconds(1f);

        countdown--;

        if(countdown == 0) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        countdownText.text = "Time Left: " + countdown;

        StartCoroutine(StartCountdown());

    }


} // class
