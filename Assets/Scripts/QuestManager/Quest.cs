using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quest
{

    public enum QuestProgress { NOT_AVAILABLE, AVAILABLE, ACCEPTED, COMPLETE, DONE }

    public string title;                //任务标题
    public int id;                      //任务ID
    public QuestProgress progress;      //当前任务状态(enum)
    public TextAsset description;       //任务描述
    public string hint;                 //任务提示
    public string congratulation;       //任务完成
    public string summery;              //任务总结
    public int nextQuest;               //下一个任务ID

    public string questObjective;       //达成任务的目标名称
    public int questObjectiveCount;     //任务目标当前的数量
    public int questObjectivRequirement;//任务目标需要的数量

    public int expReward;               //经验值奖励
    public int goldReward;              //金币奖励（或其他）
    public string itemReward;           //物品奖励
}
