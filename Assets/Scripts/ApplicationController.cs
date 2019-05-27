using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using AppMode;

public class ApplicationController : MonoBehaviour
{
    public static ApplicationController instance;
    private static string PATH = "./Assets/atlas.json";

    // public GameObject modeToggle;
    public Toggle modeToggle;
    public GameObject parent;
    AtlasLoader loader;
    AcupointAtlas atlas;
    public AppView mode;
    public AppState state;
    public AppState previousState;
    public GameObject modeDim2;


    void Awake() {

        if (instance) {
            Debug.Log("Instance already exist");
            return;
        }
        else {
            instance = this;        
        }
    }

    public AcupointAtlas GetAtlas() {
        return atlas;
    } 

    public GameObject GetParent() {
        return parent;
    }

    public void SaveAtlas() {
        loader.SaveAtlas(atlas, PATH);
    }

    public void InitModeToggle() {

        // Toggle toggle = modeToggle.GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        modeToggle.onValueChanged.AddListener(delegate {
            modeChanged(modeToggle);
        });

        //Initialise the Text to say the first state of the Toggle
        // Debug.Log("First Value : " + toggle.isOn);
    }

    //Output the new state of the Toggle into Text
    void modeChanged(Toggle toggle)
    {
        // Debug.Log("New Value : " + toggle.isOn);
        if (toggle.isOn) {
            previousState = state;
            state = AppState.dragPoint;
        }
        else { 
            state = previousState;
            //save new point position
            atlas.savePointChanges();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitModeToggle();
        mode = AppView.dim3;
        state = AppState.atlasView;

        // loader = new AtlasLoader(PATH);
        // atlas = loader.LoadAtlas();
        // atlas.render();

        atlas = new AcupointAtlas();
        UIController.instance.renderLeftMenu(atlas);
        // AcupointAtlas _atlas = new AcupointAtlas("First Atlas");
        // Acupoint _acupoint = new Acupoint("New point name", "New point description", acupointObject);
        // _atlas.addToAtlas();
        // loader.SaveAtlas(_atlas, PATH);
    }

    public void createAcupoint() {

        atlas.createAcupoint();
    }

    public void acupointSelect(int _id)
    {
        // check state
        if (state == AppState.dragPoint) {

            // switch toggle value 
            modeToggle.isOn = false;
            // then save point position
            // atlas.savePointChanges();
        }

        // highlight points in 2D/3D
        atlas.highlightAcupoint(_id); // 3D

        // show description in left menu
        UIController.instance.showInfo(atlas.getAcupointData(_id));
    }

    public void resetAcupointSelect() {

        // check state
        if (state == AppState.dragPoint) {

            // switch toggle value 
            modeToggle.isOn = false;
            // then save point position
            // atlas.savePointChanges();
        }

        atlas.removeHighlight();
        UIController.instance.hideInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetModeDim2() { mode = AppView.dim2; ShowModeDim2(); }
    public void SetModeDim3() { mode = AppView.dim3; HideModeDim2(); }

    public void HideModeDim2() { modeDim2.GetComponent<CanvasGroup>().alpha = 0f; }
    public void ShowModeDim2() { modeDim2.GetComponent<CanvasGroup>().alpha = 1f; }
}
