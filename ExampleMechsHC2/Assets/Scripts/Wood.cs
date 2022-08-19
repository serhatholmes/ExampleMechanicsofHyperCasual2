using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{

    public int speed = 3;

    void Update() {
        transform.Rotate(0f, speed, 0f);
    }


}
