using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AcupointAtlas
{
    public List<AcupointData> acupointsData;
    public List<MeridianData> meridiansData;
    public List<Acupoint> acupoints;
    public List<Meridian> meridians;
    public string atlasName;
    private Acupoint selectedAcupoint;

    public AcupointAtlas(string _atlasName) {

        atlasName = _atlasName;
        acupoints = new List<Acupoint>();
        acupointsData = new List<AcupointData>();
    }

    public AcupointAtlas() {

        meridians = new List<Meridian>();
        acupoints = new List<Acupoint>();

        meridiansData = DatabaseConnector.instance.getMeridiansDataList();
        acupointsData = DatabaseConnector.instance.getAcupointsDataList();

        foreach(AcupointData item in acupointsData) {
            Debug.Log(item.ToString());
            acupoints.Add(new Acupoint(item));
        }

        foreach(MeridianData item in meridiansData) {
            Debug.Log(item.ToString());
            meridians.Add(new Meridian(item));
        }

        Debug.Log(acupointsData.ToString());
    }

    public void savePointChanges() {
        // should be --> DatabaseConnector.instance.UpdateAcupoint(selectedAcupoint.acupointData);
        DatabaseConnector.instance.UpdateAcupoint(selectedAcupoint.getAcupointData());
    }

    public void removeHighlight() {

        selectedAcupoint.removeHighlight();
        selectedAcupoint = null;
    }

    public void highlightAcupoint(int _id) {

        if (selectedAcupoint != null) { removeHighlight(); }

        selectedAcupoint = acupoints.Find(x => x.id == _id); 
        selectedAcupoint.highlight();
    }

    public AcupointData getAcupointData(int _id) {
        
        return acupointsData.Find(x => x.id == _id);
    }

    public void createAcupoint() {

        AcupointData defaultData = new AcupointData();
        
        int index = DatabaseConnector.instance.InsertAcupoint(defaultData);
        Debug.Log("Inserted id: " + index);
        defaultData.id = index;
        // Debug.Log(defaultData.ToString());
        Acupoint createdPoint = new Acupoint(defaultData);
        acupoints.Add(createdPoint);
        acupointsData.Add(defaultData);
    }

    // public void addToAtlas(Acupoint _acupoint) {
        // 
        // acupoints.Add(_acupoint);
    // }

    public void render() {

        foreach(var acupoint in acupoints) {

            acupoint.render();
        }
    }

    public void showAcupoints() {

        foreach(var acupointData in acupointsData) {
            new Acupoint(acupointData);
        }
    }

    public override string ToString() {
        return atlasName;
    }
}
