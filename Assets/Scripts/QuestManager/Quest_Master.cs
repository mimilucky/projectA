using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Master : MonoBehaviour
{

    public delegate void QuestEventHandler(int questID);
    public event QuestEventHandler EventQuestAvailable;
    public event QuestEventHandler EventQuestAccepted;
    public event QuestEventHandler EventQuestComplete;
    public event QuestEventHandler EventQuestCompleteButton;
    public event QuestEventHandler EventQuestDone;
    public event QuestEventHandler EventQuestTextBox;


    public delegate void ShowQuestUIEventHandler();
    public event ShowQuestUIEventHandler EventShowQuestUI;

    public delegate void QuestItemEventHandler(string questObjective, int itemAmount);
    public event QuestItemEventHandler EventAddQuestItem;

    public List<Quest> questList = new List<Quest>();
    public List<Quest> currentQuestList = new List<Quest>();


    public void CallEventAddQuestItem(string questObjective, int itemAmount)
    {
        if (EventAddQuestItem != null)
        {
            EventAddQuestItem(questObjective, itemAmount);
        }
    }
    public void CallEventShowQuestUI()
    {
        if (EventShowQuestUI != null)
        {
            EventShowQuestUI();
        }
    }

    public void CallEventQuestAvailable(int questID)
    {
        if (EventQuestAvailable != null)
        {
            EventQuestAvailable(questID);
        }
    }

    public void CallEventQuestAccepted(int questID)
    {
        if (EventQuestAccepted != null)
        {
            EventQuestAccepted(questID);
        }
    }

    public void CallEventQuestComplete(int questID)
    {
        if (EventQuestComplete != null)
        {
            EventQuestComplete(questID);
        }
    }

    public void CallEventQuestCompleteButton(int questID)
    {
        if (EventQuestCompleteButton != null)
        {
            EventQuestCompleteButton(questID);
        }
    }

    public void CallEventQuestDone(int questID)
    {
        if (EventQuestDone != null)
        {
            EventQuestDone(questID);
        }
    }

    public void CallEventQuestTextBox(int questID)
    {
        if (EventQuestTextBox != null)
        {
            EventQuestTextBox(questID);
        }
    }

}
