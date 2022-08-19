using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeSpawner : MonoBehaviour {

    public Transform spawnPoint;
    public GameObject knifePrefab;

    private Text scoreText;
    private int score;

    void Awake() {
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
    }

    public void SpawnKnife() {
        GameObject go = Instantiate(knifePrefab, spawnPoint.position, spawnPoint.rotation);
        go.transform.parent = spawnPoint;
    }

    public void IncrementScore() {
        score++;
        scoreText.text = score.ToString();
    }


} // class





































