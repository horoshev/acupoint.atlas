using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Класс для работы с пользовательским вводом
// - Нажатие левой кнопки мыши
public class UserController : MonoBehaviour
{
    public LayerMask selectMask;
    Camera camera;

    void Start() {
        camera = Camera.main;

        // log();
        // DatabaseConnector.instance.CreateMeridianTable();
        // DatabaseConnector.instance.CreateDB();
    }

    void log()
    {
        // DatabaseConnector.OpenConnection();
        // DatabaseConnector.instance.CreateDB();
        // var points = DatabaseConnector.instance.GetAcupoints();
        // foreach (var point in points) {
		// 	Debug.Log(point.ToString());
		// }
    }

    void Update() {

        if (Input.GetMouseButtonDown(0)) {

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, selectMask)) {
                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log("Hit " + hit.collider.name + " " + hit.point);
                Selectable acupoint = hit.collider.GetComponent<Selectable>();
                // Debug.Log("UserController Hit " + acupoint.acupoint.name);
                Debug.Log("UserController Hit " + acupoint.ToString());
                acupoint.Select();
                // ApplicationController.instance.acupointSelect(acupoint.acupoint.id);
                // Debug.Log("UserController Hit " + acupoint.name + " " + hit.point);
            }
        }
    }
}
