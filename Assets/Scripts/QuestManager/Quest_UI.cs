using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_UI : MonoBehaviour
{
    public GameObject qButton;
    public Transform qButtonSpacer;

    private Quest_Master questMaster;
    public List<GameObject> qButtons = new List<GameObject>();

    private GameObject questButton;
    private QButtonScript qBScript;



    void OnEnable()
    {
        SetInitialReferences();
        questMaster.EventShowQuestUI += InstantiateQuestButton;
        questMaster.EventQuestAccepted += AcceptedQuest;
        questMaster.EventQuestComplete += CompleteQuest;
        questMaster.EventAddQuestItem += AddQuestItem;

    }

    void OnDisable()
    {
        questMaster.EventShowQuestUI -= InstantiateQuestButton;
        questMaster.EventQuestAccepted -= AcceptedQuest;
        questMaster.EventQuestComplete -= CompleteQuest;
        questMaster.EventAddQuestItem -= AddQuestItem;

    }


    void SetInitialReferences()
    {
        questMaster = GetComponent<Quest_Master>();
    }

    void InstantiateQuestButton()//指挥所进入初始化
    {

        foreach (Quest questList in questMaster.questList)
        {
            if (qButtons.Count < questMaster.questList.Count)
            {
                questButton = Instantiate(qButton);
                qBScript = questButton.GetComponent<QButtonScript>();
                qBScript.questID = questList.id;
                qBScript.questTitle.text = questList.title;

                questButton.transform.SetParent(qButtonSpacer, false);
                qButtons.Add(questButton);

                if (qBScript.questID == questList.id && questList.progress == Quest.QuestProgress.NOT_AVAILABLE)
                {
                    questButton.SetActive(false);
                }
                if (qBScript.questID == questList.id && (questList.progress == Quest.QuestProgress.AVAILABLE ||
                    questList.progress == Quest.QuestProgress.COMPLETE ||
                    questList.progress == Quest.QuestProgress.ACCEPTED))
                {
                    questButton.SetActive(true);
                    if (questList.progress == Quest.QuestProgress.AVAILABLE)
                    {
                        qBScript.questState.text ="接受";
                    }
                }
                if (qBScript.questID == questList.id && questList.progress == Quest.QuestProgress.DONE)
                {
                    questButton.GetComponentInChildren<Button>().interactable = false;
                }

            }
        }
    }
    
    void AcceptedQuest(int questID)//接受任务
    {
        for (int i = 0; i < questMaster.questList.Count; i++)
        {
            if (questMaster.questList[i].id == questID && questMaster.questList[i].progress == Quest.QuestProgress.AVAILABLE)
            {
                questMaster.currentQuestList.Add(questMaster.questList[i]);
                questMaster.questList[i].progress = Quest.QuestProgress.ACCEPTED;

            }
        }
    }

    void CompleteQuest(int questID)//完成任务
    {
        for (int i = 0; i < questMaster.currentQuestList.Count; i++)
        {
            if (questMaster.currentQuestList[i].id == questID && questMaster.currentQuestList[i].progress == Quest.QuestProgress.COMPLETE)
            {
                questMaster.currentQuestList[i].progress = Quest.QuestProgress.DONE;
                // 完成任务, 执行任务奖励
                int expReward = questMaster.currentQuestList[i].expReward;                
                Debug.Log("经验增加" + expReward);
                int goldReward = questMaster.currentQuestList[i].goldReward;
                Debug.Log("金币增加" + goldReward);
                string itemReward = questMaster.currentQuestList[i].itemReward;
                 Debug.Log("获得物品" + itemReward);             
                                
                questMaster.currentQuestList.Remove(questMaster.currentQuestList[i]);
                CheckChainQuest(questID);
                questMaster.CallEventQuestDone(questID);
            }
        }

    }

    void CheckChainQuest(int questID)//检查激活下一个任务按钮
    {

        int tempID = 0;
        for (int i = 0; i < questMaster.questList.Count; i++)
        {
            if (questMaster.questList[i].id == questID && questMaster.questList[i].nextQuest > 0)
            {
                tempID = questMaster.questList[i].nextQuest;
            }
        }
        if (tempID > 0)
        {
            for (int i = 0; i < questMaster.questList.Count; i++)
            {
                if (questMaster.questList[i].id == tempID && questMaster.questList[i].progress == Quest.QuestProgress.NOT_AVAILABLE)
                {
                    questMaster.questList[i].progress = Quest.QuestProgress.AVAILABLE;
                    questMaster.CallEventQuestAvailable(tempID);
                    
                }
            }
        }
    }

    void AddQuestItem(string questObjective, int itemAmount)//收集物品任务增加收集数量
    {
        for (int i = 0; i < questMaster.currentQuestList.Count; i++)
        {
            if (questMaster.currentQuestList[i].questObjective == questObjective && questMaster.currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                if (questMaster.currentQuestList[i].questObjectivRequirement > questMaster.currentQuestList[i].questObjectiveCount)
                {
                    questMaster.currentQuestList[i].questObjectiveCount += itemAmount;
                }
                else
                {
                    questMaster.currentQuestList[i].progress = Quest.QuestProgress.COMPLETE;
                    questMaster.CallEventQuestCompleteButton(questMaster.currentQuestList[i].id);
                }
            }
        }
    }


}
