using System;
// using System.Collections;
using UnityEngine;
// using EditorUtility;
using UnityEditor;

[Serializable]
public class Acupoint
{
    // public GameObject sceneObject;
    public Transform parent;
    public Vector3 position;
    public string name;
    public string description;
    private int objID = 0;
    private GameObject acupoint;

    // public Acupoint(string _name, string _description, GameObject _object) {
    public Acupoint(string _name, string _description, Vector3 _position, Transform _parent) {

        // sceneObject = _object;
        name = _name;
        description = _description;

        position = _position;
        parent = _parent;
    }

    public void render() {

        // GameObject acupoint;
        acupoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject model = ApplicationController.instance.GetParent();
        acupoint.transform.SetParent(model.transform);
        acupoint.transform.localPosition = position;
        acupoint.layer = 9;

        // if (objID != 0) {
            // // GameObject obj = GameObject.Find(objID.ToString());
            // // GameObject.Destroy(obj);

            // GameObject obj = GameObject.Find(objID.ToString());
            // if (obj != null) {
                // Debug.Log("not null" + obj.ToString());
            // } else {
                // Debug.Log("null" + obj.ToString());
            // }
            // // Destroy(GameObject.Find(objID.ToString()));

            // // Object obj = EditorUtility.InstanceIDToObject(objID);
            // // Destroy(obj);

        // }
        
        // objID = acupoint.GetInstanceID();
        
        // acupoint.AddComponent<Selectable>();
        // AcupointSelect acupointSelect = acupoint.AddComponent<AcupointSelect>();
        // acupointSelect.SetAcupoint(this);
        // acupoint.AddComponent<AcupointSelect>().SetAcupoint(this);

        AcupointSelect acupointSelect = AcupointSelect.Create(acupoint, this);
    }

    public void ChangePosition(Vector3 _position) {

        acupoint.transform.localPosition = _position;
    }
}
