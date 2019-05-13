using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public LayerMask selectMask;
    Camera camera;

    void Start() {
        camera = Camera.main;
    }

    void Update() {

        if (Input.GetMouseButtonDown(0)) {

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, selectMask)) {
                // Debug.Log("Hit " + hit.collider.name + " " + hit.point);
                Selectable acupoint = hit.collider.GetComponent<Selectable>();
                acupoint.Select();

                

                // Debug.Log("UserController Hit " + acupoint.name + " " + hit.point);

            }
        }
    }
}
