using UnityEngine;

public class AcupointSelect : Selectable {

    public Acupoint acupoint;
    public int aid;

    public override void Select() {

        base.Select();
        ShowInfo();
    }

    // public AcupointSelect() {}

    public static AcupointSelect Create(GameObject obj, Acupoint _acupoint) {

        AcupointSelect acupointSelect = obj.AddComponent<AcupointSelect>();
        acupointSelect.acupoint = _acupoint;

        return acupointSelect;
    }

    public void SetAcupoint(Acupoint _acupoint) {
        acupoint = _acupoint;
    }

    void ShowInfo() {

        Debug.Log("Acupoint Select " + acupoint.name);

        //showing in dev panel
        // fixed(Acupoint* point = &acupoint)
        // {
        //     UIController.instance.DisplayAcupointInfo(point);
        // }

        aid = UIController.instance.DisplayAcupointInfo(acupoint);
        Debug.Log(aid.ToString());
        // while(UIController.instance.aid == aid) {
            
        //     if (UIController.instance.changed) {
        //         UIController.instance.displayAcupoint = acupoint;
        //         UIController.instance.changed = false;
        //     }
        // }
    }

    void Update() {

        if (UIController.instance.aid == aid) {

            // Debug.Log(aid.ToString() + " Monitoring");
            if (UIController.instance.changed) {
                // UIController.instance.displayAcupoint = acupoint;
                // acupoint.render();
                acupoint.ChangePosition(UIController.instance.displayAcupoint.position);
                UIController.instance.changed = false;
                ApplicationController.instance.SaveAtlas();
            }
        }
    }
}