using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPostCanvas : MonoBehaviour {

    public QuestDialogue_Master questTextBox;
    private Quest_Master questMaster;

    void Start()
    {
        questMaster = GetComponent<Quest_Master>();
    }



    public void HideCanvas(bool b)
    {
        questMaster.CallEventShowQuestUI();
        questTextBox.DisableThis();
        
        if (b)
            CanvasShowOff.Instance.HideAdd(gameObject.name);
        else
            CanvasShowOff.Instance.ShowAdd(gameObject.name);

    }
}
