using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlScript : MonoBehaviour {


    public float horizontalSpeed;
    public float verticalSpeed;
    private Camera gameCamera;

    void Start() {
        gameCamera = this.GetComponentInChildren<Camera>();
    }
    private void Update() {
        if (Input.GetMouseButton(2)) {
            var h = horizontalSpeed * -(Input.GetAxis("Mouse X"));// * -(Input.GetAxis("Mouse X")+ Input.GetAxis("Mouse Y"));
            var v = verticalSpeed * -(Input.GetAxis("Mouse Y"));// * -(Input.GetAxis("Mouse Y")- Input.GetAxis("Mouse X"));
            transform.Translate(h, v,0);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            gameCamera.transform.Translate (new Vector3(0,0,10*Input.GetAxis("Mouse ScrollWheel")));
        }
    }







}