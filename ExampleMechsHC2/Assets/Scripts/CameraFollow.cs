using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector3 offset;
    private GameObject player;

    void Awake() {
        player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if(player) {
            transform.position = player.transform.position + offset;
        }
    }

} // class
