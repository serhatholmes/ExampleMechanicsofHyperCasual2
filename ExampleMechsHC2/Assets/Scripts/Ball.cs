using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody myBody;
    public float speed = 400f;

    private Camera mainCam;

    void Awake() {
        myBody = GetComponent<Rigidbody>();
    }

    void Start() {
        mainCam = Camera.main;
    }

    void Update() {
        CheckIfFallDown();
    }

    void FixedUpdate() {

        Movement();
        MobileMovement();

    }

    void Movement() {

        float hoz_Axis = Input.GetAxis("Horizontal") * (Time.deltaTime * 2f);
        float vert_Axis = Input.GetAxis("Vertical") * (Time.deltaTime * 2f);

        Vector3 vert_Cam = mainCam.transform.forward;
        Vector3 hoz_Cam = mainCam.transform.right;

        vert_Cam.y = 0f;
        hoz_Cam.y = 0f;

        vert_Cam.Normalize();
        hoz_Cam.Normalize();

        Vector3 playerMove = (vert_Cam * vert_Axis + hoz_Cam * hoz_Axis) * speed;

        myBody.AddForce(playerMove);

    } // movement

    void MobileMovement() {


        if(Input.GetMouseButton(0)) {

            RaycastHit hit;

            Ray currentRay = mainCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(currentRay, out hit)) {

                Vector3 newPos = hit.point;
                Vector3 currentPos = transform.position;
                Vector3 direction = newPos - currentPos;
                direction.Normalize();
                direction.y = 0f;

                myBody.AddForce(direction * speed * (Time.deltaTime * 2f));


            }


        }


    } // mobile movement

    void CheckIfFallDown() { 

        if(transform.position.y < -2f) {

            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        }

    }

    void RestartLevel() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter(Collision target) {

        if(target.gameObject.tag == "Finish") {
            Invoke("RestartLevel", 2f);
        }

    }


} // class






























