using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoContainer : MonoBehaviour
{
    public Button exitButton;
    public Text title;
    public Text description;

    void Start()
    {
        exitButton.onClick.AddListener(() => exitButtonClick());
    }

    public void setInfo(AcupointData _point)
    {
        title.text = _point.name;
        description.text = _point.description;
        // SetActive(false);
    }

    public void exitButtonClick()
    {
        // SetActive(false);
        ApplicationController.instance.resetAcupointSelect();
    }
}
