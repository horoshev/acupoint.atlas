using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAcupointButtonScript : MonoBehaviour
{
    public Button addAcupointButton; 
    public Transform target;

    void Start() {
        addAcupointButton.onClick.AddListener(OnClick);
    }

    void OnClick() {
        
        GameObject acupointObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        acupointObject.transform.SetParent(target);
        acupointObject.transform.localPosition = new Vector3(-15.0f, 15.0f, 0);
        acupointObject.layer = 9;

        acupointObject.AddComponent<Selectable>();

        // Acupoint acupoint = new Acupoint("Unnamed acupoint", "New acupoint", acupointObject);
        Acupoint acupoint = new Acupoint("Unnamed acupoint", "New acupoint", acupointObject.transform.localPosition, target);

        // ApplicationController.instance.GetAtlas().addToAtlas(acupoint);
        ApplicationController.instance.SaveAtlas();
    }
}
