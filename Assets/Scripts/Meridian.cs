using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Meridian {

    // public Transform parent;
    public MeridianData meridianData;
    public Material material;
    public Color meridianDefaultColor;
    public Color meridianHighlightColor;
    private GameObject meridian;
    private GameObject meridian2d;

    public Meridian(/* Transform _parent, */ MeridianData _meridianData) {

        // parent = _parent;
        // parent = UIController.instance.img2d;
        meridianData = _meridianData;
        meridianDefaultColor = Color.black;
        meridianHighlightColor = Color.red;
        material = new Material(Shader.Find("UI/Default"));
        render();
    }

    public void highlight() {

        material.color = meridianHighlightColor;
    }

    public void removeHighlight() {

        material.color = meridianDefaultColor;

    }

    public void render() {

        // 2d render
        GameObject img2d = UIController.instance.img2d;
        GameObject line2d = new GameObject();
        UILineRenderer line = line2d.AddComponent<UILineRenderer>();
        // line.useWorldSpace = false;
        // line.SetColors(Color.red, Color.yellow);

        line.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);

        Vector2[] positions = new Vector2[3];
        var z = 0.00f;
        positions[0] = new Vector2(-200.0f, -200.0f);
        positions[1] = new Vector2(0.0f, 200.0f);
        positions[2] = new Vector2(200.0f, -200.0f);
        // line.positionCount = positions.Length;
        // line.SetPositions(positions);
        // line.Simplify(0.02f);

        line.Points = positions;
        // Material material = new Material(Shader.Find("Transparent/Diffuse"));
        material.color = meridianDefaultColor;
        line.material = material;
        // line2d.GetComponent<Renderer>().material.color = Color.red;
        // line.material.color = Color.white;
        // line.mainTexture.color = Color.red;
        // line.sprite. olor = Color.red;
        // line.Color = Color.red;

        line2d.transform.SetParent(img2d.transform, false);
        line2d.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

        line.transform.SetParent(line2d.transform, false);
        line.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

        // set values
        // meridian2d = new 
        // line.transform.SetParent(img2d.transform, false);
        // line.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        // line.GetComponent<Button>().onClick.AddListener(() => pointButtonClick(id));
    }
}