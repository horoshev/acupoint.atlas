using UnityEngine;
using UnityEngine.UI;

public class AccordionItem : MonoBehaviour
{
    public Toggle expandToggle;
    public GameObject expandPanel;
    public GameObject pointButton;

    void Start()
    {
        expandToggle.onValueChanged.AddListener(delegate {
            onToggleValueChange();
        });
    }

    public void setToggleTitle(string _title)
    {
        expandToggle.GetComponentInChildren<Text>().text = _title;
    }

    public GameObject addButton(int _id, string _title) {
        // create new button
        GameObject spawnButton = (GameObject) GameObject.Instantiate(pointButton);

        // set values
        spawnButton.GetComponentInChildren<Text>().text = _title;
        spawnButton.transform.SetParent(expandPanel.transform, false);
        spawnButton.GetComponent<Button>().onClick.AddListener(() => pointButtonClick(_id));

        return spawnButton;
    }

    public void pointButtonClick(int _id) {
        ApplicationController.instance.acupointSelect(_id);
    }

    public void onToggleValueChange()
    {
        expandPanel.SetActive(!expandPanel.activeSelf);
    }

}