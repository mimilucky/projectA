using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QButtonScript : MonoBehaviour
{
    private Quest_Master questMaster;
    private Quest_UI questUI;
    public TextAsset theText;
    public string[] textLines;
    private int startLine;
    private int endLine;
    private bool isActive;

    public int questID;
    public Text questState;
    public Text questTitle;

    public QuestDialogue_Master questTextBox;
    public Text boxText;


    void OnEnable()
    {
        SetInitialReferences();
        questMaster.EventQuestAvailable += QuestButtonAvailable;
        questMaster.EventQuestAccepted += QuestButtonAccepted;
        questMaster.EventQuestAccepted += QuestDialogue;
        questMaster.EventQuestCompleteButton += QuestButtonComplete;
        questMaster.EventQuestDone += QuestButtonDone;

    }
    void OnDisable()
    {
        questMaster.EventQuestAvailable -= QuestButtonAvailable;
        questMaster.EventQuestAccepted -= QuestButtonAccepted;
        questMaster.EventQuestAccepted -= QuestDialogue;
        questMaster.EventQuestCompleteButton -= QuestButtonComplete;
        questMaster.EventQuestDone -= QuestButtonDone;
    }


    void Start()
    {
        foreach (Quest questList in questMaster.questList)
        {
            if (questID == questList.id)
            {
                theText = questList.description;
            }

        }
    }

    void SetInitialReferences()
    {
        questMaster = GameObject.Find("CommandPostCanvas").GetComponent<Quest_Master>();
        questUI = GameObject.Find("CommandPostCanvas").GetComponent<Quest_UI>();

    }

    void QuestButtonAvailable(int qID)
    {
        foreach (GameObject qButton in questUI.qButtons)
        {
            if (qID == qButton.GetComponent<QButtonScript>().questID)
            {
                qButton.SetActive(true);
                qButton.GetComponent<QButtonScript>().questState.text = "接受";
            }
        }
        gameObject.SetActive(true);        
    }

    void QuestButtonAccepted(int qID)
    {

        foreach (Quest questList in questMaster.questList)
        {
            if (qID == questID)
            {
                if (qID == questList.id && questList.progress == Quest.QuestProgress.ACCEPTED)
                {
                    questState.text = "查看";
                }
            }

        }

    }

    void QuestButtonComplete(int qID)
    {
        foreach (Quest questList in questMaster.questList)
        {
            if (qID == questID)
            {
                if (qID == questList.id && questList.progress == Quest.QuestProgress.COMPLETE)
                {
                    questState.text = "完成";
                }
            }

        }

    }

    void QuestButtonDone(int qID)
    {

        foreach (Quest questList in questMaster.questList)
        {
            if (qID == questID)
            {
                if (qID == questList.id && questList.progress == Quest.QuestProgress.DONE)
                {
                    questState.text = "已完成";
                    gameObject.GetComponentInChildren<Button>().interactable = false;
                }
            }

        }

    }

    void QuestDialogue(int qID)
    {
        foreach (Quest questList in questMaster.questList)
        {
            if (qID == questID)
            {
                if (qID == questList.id && (questList.progress == Quest.QuestProgress.ACCEPTED || questList.progress == Quest.QuestProgress.AVAILABLE))
                {
                    if (questTextBox != null)
                    {
                        if (questTextBox.enabled == false)
                        {
                        questTextBox.enabled = true;
                        questTextBox.ReloudScript(theText);
                        questTextBox.currentLine = startLine;
                        questTextBox.endAtLine = endLine;
                        questTextBox.EnableThis();
                        }
                        else
                        {
                            questTextBox.enabled = false;
                            questTextBox.enabled = true;
                            questTextBox.ReloudScript(theText);
                            questTextBox.currentLine = startLine;
                            questTextBox.endAtLine = endLine;
                            questTextBox.EnableThis();
                        }
                    }
                }
            }

        }

    }

    public void OnClickQButton()
    {

        if (questID > 0)
        {

            questMaster.CallEventQuestAccepted(questID);
            questMaster.CallEventQuestComplete(questID);

        }


    }


}
