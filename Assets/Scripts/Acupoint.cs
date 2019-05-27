using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[Serializable]
public class Acupoint
{
    // public GameObject sceneObject;
    public Transform parent;
    public Vector3 pos2d;
    public Vector3 pos3d;
    // Vector3 scaleV = new Vector3(0.25f, 0.25f, 0.25f);
    public Color defaultColor = Color.black;
    public Color highlightColor = Color.red;
    public string name;
    public string description;
    public int id;
    public int meridian_id;
    private GameObject acupoint;
    private GameObject acupoint2d;

    // events
    public static event Action<Acupoint> OnPointSelected;

    // public Acupoint(string _name, string _description, GameObject _object) {
    public Acupoint(string _name, string _description, Vector3 _position, Transform _parent) {

        // sceneObject = _object;
        name = _name;
        description = _description;

        pos3d = _position;
        parent = _parent;
    }

    public Acupoint(AcupointData _data) {
        setAcupointData(_data);
        render();
    }

    // public override void Select() {

    //     Debug.Log("acu 1");
    //     base.Select();
    //     Debug.Log("acu 2");
    //     ApplicationController.instance.acupointSelect(id);
    //     Debug.Log("acu 3");
    // }

    public void highlight() {

        acupoint.AddComponent<DragPoint3d>();
        acupoint2d.AddComponent<DragPoint2d>();
        acupoint.GetComponent<Renderer>().material.color = highlightColor;
        acupoint2d.GetComponent<Image>().color = Color.black;
    }

    public void removeHighlight() {

        UnityEngine.Object.Destroy(acupoint.GetComponent<DragPoint3d>() as UnityEngine.Object);
        UnityEngine.Object.Destroy(acupoint2d.GetComponent<DragPoint2d>() as UnityEngine.Object);
        acupoint.GetComponent<Renderer>().material.color = defaultColor;
        acupoint2d.GetComponent<Image>().color = Color.white;
    }

    public void render() {

        // GameObject acupoint;
        acupoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // acupoint.transform.localScale = Vector3.Scale(acupoint.transform.localScale, scaleV);
        // acupoint.transform.localScale = acupoint.transform.localScale * scale;
        acupoint.transform.localScale *= 0.25f;
        GameObject model = ApplicationController.instance.GetParent();
        // acupoint.AddComponent<Selectable>();
        acupoint.transform.SetParent(model.transform);
        acupoint.transform.localPosition = pos3d;
        acupoint.layer = 9;
        acupoint.GetComponent<Renderer>().material.color = defaultColor;
        // acupoint.AddComponent<Selectable>();
        AcupointSelect acupointSelect = AcupointSelect.Create(acupoint, this);

        // 2d render
        GameObject img2d = UIController.instance.img2d;
        GameObject img2dPoint = UIController.instance.img2dPoint;
        acupoint2d = (GameObject) GameObject.Instantiate(img2dPoint);
        // acupoint2d.AddComponent<DragPoint>();

        // set values
        acupoint2d.transform.SetParent(img2d.transform, false);
        acupoint2d.transform.localPosition = pos2d;
        acupoint2d.GetComponent<Button>().onClick.AddListener(() => pointButtonClick(id));
    }

    public void pointButtonClick(int _id) {
        ApplicationController.instance.acupointSelect(_id);
    }

    public void ChangePosition(Vector3 _position) {

        acupoint.transform.localPosition = _position;
    }

    public void PointSelected() {

        // if (OnPointSelected) {
        //     OnPointSelected(this);
        // }
    }

    public AcupointData getAcupointData()
    {
        pos3d = acupoint.transform.localPosition;
        pos2d = acupoint2d.GetComponent<RectTransform>().anchoredPosition; // transform.localPosition;
        Debug.Log(pos2d);

        return new AcupointData {
			id = id,
			name = name,
			description = description,
            meridian_id = meridian_id,
            pos2d_x = pos2d.x,
            pos2d_y = pos2d.y,
            pos3d_x = pos3d.x,
            pos3d_y = pos3d.y,
            pos3d_z = pos3d.z,
		};
    }

    public void setAcupointData(AcupointData _data)
    {
		id = _data.id;
		name = _data.name;
		description = _data.description;
        meridian_id = _data.meridian_id;
        pos2d.x = _data.pos2d_x;
        pos2d.y = _data.pos2d_y;
        pos2d.z = 0;
        pos3d.x = _data.pos3d_x;
        pos3d.y = _data.pos3d_y;
        pos3d.z = _data.pos3d_z;
    }
}
