using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    public static ApplicationController instance;
    private static string PATH = "./Assets/atlas.json";

    public GameObject parent;
    AtlasLoader loader;
    AcupointAtlas atlas;

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

    // Start is called before the first frame update
    void Start()
    {
        loader = new AtlasLoader(PATH);
        // AcupointAtlas _atlas = new AcupointAtlas("First Atlas");
        // Acupoint _acupoint = new Acupoint("New point name", "New point description", acupointObject);
        // _atlas.addToAtlas();
        // loader.SaveAtlas(_atlas, PATH);
        atlas = loader.LoadAtlas();
        atlas.render();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
