using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Acupoint displayAcupoint;
    public int aid = 0;
    public bool changed = false;
    public InputField NameTextBox;
    public InputField DescriptionTextBox;
    public InputField PosXTextBox;
    public InputField PosYTextBox;
    public InputField PosZTextBox;
    public InputField searchLine;

    public GameObject img2d;
    public GameObject img2dPoint; //prefab

    public GameObject Accordion;
    public GameObject AccordionItem; // prefab

    public bool isSelected = false;
    public GameObject infoPanel;
    public GameObject accordionPanel;

    public List<GameObject> buttonsList;
    public delegate void OnAcupointSelected(string _name);
    public OnAcupointSelected OnAcupointSelectedCallback;

    void Awake() {

        if (instance) {
            Debug.Log("Instance already exist");
            return;
        }
        else {
            instance = this;        
        }
    }

    public int DisplayAcupointInfo(Acupoint _acupoint) {

        // fixed(Acupoint* point = _acupoint)
        // {
        //     displayAcupoint = point;
        // }

        displayAcupoint = _acupoint;
        
        NameTextBox.text = displayAcupoint.name;
        DescriptionTextBox.text = displayAcupoint.description;

        string posX = Math.Round(displayAcupoint.pos3d.x, 2, MidpointRounding.AwayFromZero).ToString();
        string posY = Math.Round(displayAcupoint.pos3d.y, 2, MidpointRounding.AwayFromZero).ToString();
        string posZ = Math.Round(displayAcupoint.pos3d.z, 2, MidpointRounding.AwayFromZero).ToString();

        // Debug.Log(posX + " " + posY + " " + posZ);

        PosXTextBox.text = posX;
        PosYTextBox.text = posY;
        PosZTextBox.text = posZ;

        // if (OnAcupointSelectedCallback != null)
        //     OnAcupointSelectedCallback.Invoke();

        changed = false;
        aid++;

        return aid;
    }

    public Acupoint GetAcupoint() {
        return displayAcupoint;
    }

    #region ChangeMethods

    // public void render2dPoints(AcupointAtlas _atlas) {
        
    //     Debug.Log("Render 2d points");

    //     foreach(MeridianData meridian in _atlas.meridiansData) {

    //         Debug.Log("RLM foreach");

    //         // create new accordion item
    //         GameObject spawnItem = (GameObject) GameObject.Instantiate(AccordionItem);
    //         // set values
    //         AccordionItem accordionItem = spawnItem.GetComponent<AccordionItem>();
    //         accordionItem.setToggleTitle(meridian.name);
    //         spawnItem.transform.SetParent(Accordion.transform, false);
    //         // add buttons for points in this meridian
    //         foreach(AcupointData acupoint in _atlas.acupointsData.Where(x => x.meridian_id == meridian.id)) {
    //             Debug.Log("RLM foreach buttons");

    //             accordionItem.addButton(acupoint.id, acupoint.name);
    //         }
    //     }
    // }

    public void renderLeftMenu(AcupointAtlas _atlas, string search = "") {
        
        Debug.Log("Render left menu");

        // foreach(Transform child in Accordion.transform) {
        //     Destroy(child);
        // }

        foreach(MeridianData meridian in _atlas.meridiansData) {

            Debug.Log("RLM foreach");

            // create new accordion item
            GameObject spawnItem = (GameObject) GameObject.Instantiate(AccordionItem);
            // set values
            AccordionItem accordionItem = spawnItem.GetComponent<AccordionItem>();
            accordionItem.setToggleTitle(meridian.name);
            spawnItem.transform.SetParent(Accordion.transform, false);
            // add buttons for points in this meridian
            var list = _atlas.acupointsData
                            .Where(x => x.meridian_id == meridian.id);
                            // .Where(x => x.name.ToLower().Contains(search.ToLower()));

            foreach(AcupointData acupoint in list) {
                Debug.Log("RLM foreach buttons");

                buttonsList.Add(accordionItem.addButton(acupoint.id, acupoint.name));
            }
        }
    }

    public void liveReload(string search) {
        foreach(var button in buttonsList) {
            if (button.GetComponentInChildren<Text>().text.ToLower().Contains(search.ToLower())) {
                button.SetActive(true);
            } else {
                button.SetActive(false);
            }
        }
    }

    public void liveSearch() {
        liveReload(searchLine.text);
        // renderLeftMenu(ApplicationController.instance.GetAtlas(), searchLine.text);
    }

    public void showInfo(AcupointData _point) {

        isSelected = true;
        InfoContainer icontainer = infoPanel.GetComponentInChildren<InfoContainer>();
        icontainer.setInfo(_point);
        accordionPanel.SetActive(false);
        infoPanel.SetActive(true);

        // images
        // displayAcupoint = acupoint;
        displayAcupointImages(_point.name);
    }

    public void hideInfo() {

        isSelected = false;
        infoPanel.SetActive(false);
        accordionPanel.SetActive(true);
    }

    public void displayAcupointImages(string _name) {

        if (OnAcupointSelectedCallback != null)
            OnAcupointSelectedCallback.Invoke(_name);
    }

    public void NameChanged() {

        changed = true;
        displayAcupoint.name = NameTextBox.text;
    }

    public void DescriptionChanged() {
        
        changed = true;
        displayAcupoint.description = DescriptionTextBox.text;
    }
    
    public void PosChanged() {

        changed = true;

        if (PosXTextBox.text != "")
        displayAcupoint.pos3d.x = float.Parse(PosXTextBox.text);

        if (PosYTextBox.text != "")
        displayAcupoint.pos3d.y = float.Parse(PosYTextBox.text);

        if (PosZTextBox.text != "")
        displayAcupoint.pos3d.z = float.Parse(PosZTextBox.text);
    }

    #endregion ChangeMethods

    // Update is called once per frame
    void Update()
    {
        
    }
}
