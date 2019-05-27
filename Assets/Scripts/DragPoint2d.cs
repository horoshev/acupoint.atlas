using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPoint2d : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 screenPoint;
    private float sensitivity = 0.8f;

    // void OnMouseDown() {
    //     Vector3 scanPos = transform.position;
    //     screenPoint = Camera.main.WorldToScreenPoint(scanPos);
    //     offset = scanPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    // }

    // void OnMouseDrag() {

    //     Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    //     Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    //     transform.position = curPosition;
    // }

    void Update () {

        if (ApplicationController.instance.state != AppState.dragPoint || ApplicationController.instance.mode != AppView.dim2) { return; }

        if (Input.GetKey(KeyCode.LeftArrow)) {

            Vector3 position = this.transform.localPosition;
            position.x -= sensitivity;
            this.transform.localPosition = position;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {

            Vector3 position = this.transform.localPosition;
            position.x += sensitivity;
            this.transform.localPosition = position;
        }

        // z dim
        /* if (Input.GetKey(KeyCode.Z)) {

            if (Input.GetKey(KeyCode.UpArrow)) {

                Vector3 position = this.transform.localPosition;
                position.z += sensitivity;
                this.transform.localPosition = position;
            }

            if (Input.GetKey(KeyCode.DownArrow)) {

                Vector3 position = this.transform.localPosition;
                position.z -= sensitivity;
                this.transform.localPosition = position;
            }

            return;
        }*/

        if (Input.GetKey(KeyCode.UpArrow)) {

            Vector3 position = this.transform.localPosition;
            position.y += sensitivity;
            this.transform.localPosition = position;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {

            Vector3 position = this.transform.localPosition;
            position.y -= sensitivity;
            this.transform.localPosition = position;
        }
    }
}