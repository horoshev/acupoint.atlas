using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    // private GameObject acupoint;
    private Vector3 mouseStartPosition, mouseDragStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        // acupoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // acupoint.transform.position = new Vector3(-5.0f, 5.0f, 0);
        // acupoint.transform.SetParent(target);
        // acupoint.layer = 9;
    }

    // Update is called once per frame
    void Update()
    {
        if (ApplicationController.instance.mode != AppView.dim3) { return; }

        if (Input.GetMouseButtonDown(0)) {
            mouseStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0)) {
            var focusPoint = target.transform.GetComponent<Renderer>().bounds.center;
            var mouseCurrentPosition = Input.mousePosition;

            var dp = 5; // 100
            var dx = mouseStartPosition.x - mouseCurrentPosition.x;
            var dy = mouseStartPosition.y - mouseCurrentPosition.y;
            mouseStartPosition = mouseCurrentPosition;

            // transform.Rotate(0.0f, dx / dp, 0.0f, Space.Self);
            // transform.Rotate(dy / dp, 0.0f, 0.0f, Space.World);

            transform.RotateAround(focusPoint, Vector3.up, dx / dp);
            transform.RotateAround(focusPoint, Vector3.left, dy / dp);
        }

        if (Input.GetMouseButtonDown(1)) {
            mouseDragStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1)) {
            var focusPoint = target.transform.GetComponent<Renderer>().bounds.center;
            var mouseCurrentPosition = Input.mousePosition;

            var ds = 1000;
            var dp = mouseDragStartPosition - mouseCurrentPosition;

            transform.position -= dp / ds;
        }

        var minFov = 15f;
        var maxFov = 90f;
        var sensitivity = 10f;

        var fov = Camera.main.fieldOfView;
        // fov += Input.mouseScrollDelta.y * sensitivity;
        // Debug.Log(Input.GetAxis("Mouse ScrollWheel").ToString());
        // Debug.Log(Camera.main.fieldOfView.ToString());
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
