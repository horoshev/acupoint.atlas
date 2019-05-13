using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagesPanelUI : MonoBehaviour
{   
    UIController ui;

    public Image m_Image;
    public Sprite m_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        ui = UIController.instance;
        ui.OnAcupointSelectedCallback += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI() {

        // Debug.Log("Update UI");
        var name = ui.displayAcupoint.name; 
        //Get Images
        List<Image> images = GetImagesByName(name);
        
        //Insert to images panel
        // foreach(var image in images) {

        //     //add to images panel
        //     InsertToImagesPanel(image);
        // }
    }

    List<Image> GetImagesByName(string _name) {

        Debug.Log(_name);
        var path = @"Sprites/" + _name;
        var url = @"file://D:/UnityProjects/Atlas/Assets/LU2.png";
        // var im = Resourses.Load<Image>(path);
        // GetComponent<Image>().SourceImage = im;

        // MyImage.AddComponent(typeof(Image));
        // img = Resources.Load<Sprite>(path);
        // MyImage.GetComponent<Image>().sprite = img;
        // Debug.Log("Test script started");

        // Texture2D temp = new Texture2D(0,0);
        // WWW www = new WWW(url);
        // yield return www;
        // m_Sprite = Resources.Load<Sprite>(www.texture);
        // m_Image = GetComponent<Image>();

        // m_Sprite  = Resources.Load("Sprites/LU2") as Sprite;
        m_Sprite = Resources.Load<Sprite>(path);
        // m_Image.sprite = m_Sprite;
        m_Image.overrideSprite = m_Sprite;

        // List<Image> images = new List<Image>();
        // images.Add(m_Image);

        return null;
    }

    void InsertToImagesPanel(Image _image) {

        return;
    }
}
