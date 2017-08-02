using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private Quest_Master questMaster;

    void Start()
    {
        questMaster = GetComponent<Quest_Master>();
    }

    //测试用脚本  接到任务后，按Q是完成任务1，按W是完成任务2，按3是完成任务3，按4是完成任务4，按5是完成任务5，
    //通关之后只用只用再代码后面加一句  questMaster.CallEventAddQuestItem("任务目标", 任务数量) 任务数量达到标准及完成任务。
    //通关奖励脚本还没有写。
    void Update()  
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            questMaster.CallEventAddQuestItem("quest1", 1);

        }
        if (Input.GetKeyDown(KeyCode.W))
        {

            questMaster.CallEventAddQuestItem("quest2", 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            questMaster.CallEventAddQuestItem("quest3", 1);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            questMaster.CallEventAddQuestItem("quest4", 1);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {

            questMaster.CallEventAddQuestItem("quest5", 1);
        }
    }
}
