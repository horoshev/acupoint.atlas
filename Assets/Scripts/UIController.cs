using System;
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

    public delegate void OnAcupointSelected();
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

        string posX = Math.Round(displayAcupoint.position.x, 2, MidpointRounding.AwayFromZero).ToString();
        string posY = Math.Round(displayAcupoint.position.y, 2, MidpointRounding.AwayFromZero).ToString();
        string posZ = Math.Round(displayAcupoint.position.z, 2, MidpointRounding.AwayFromZero).ToString();

        // Debug.Log(posX + " " + posY + " " + posZ);

        PosXTextBox.text = posX;
        PosYTextBox.text = posY;
        PosZTextBox.text = posZ;

        if (OnAcupointSelectedCallback != null)
            OnAcupointSelectedCallback.Invoke();

        changed = false;
        aid++;

        return aid;
    }

    public Acupoint GetAcupoint() {
        return displayAcupoint;
    }

    #region ChangeMethods

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
        displayAcupoint.position.x = float.Parse(PosXTextBox.text);

        if (PosYTextBox.text != "")
        displayAcupoint.position.y = float.Parse(PosYTextBox.text);

        if (PosZTextBox.text != "")
        displayAcupoint.position.z = float.Parse(PosZTextBox.text);
    }

    #endregion ChangeMethods

    // Update is called once per frame
    void Update()
    {
        
    }
}
