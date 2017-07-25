using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ship Girl _ Common
public class cSG_Com {
}

// Ship Girl _ Ship Type
public enum eST {
	DD,							// 驱逐
	CL,							// 轻巡
	CA,							// 重巡
	BB,							// 战列
	CVL,						// 轻母
	CV,							// 航母
	SS,							// 潜艇
	CLT,						// 雷巡
	Length
}

// Ship Girl _ Attribute Type
public enum eSG_AT {
	HP,							// 耐久
	Armor,						// 装甲
	Power,					// 火力
	Torpedo,					// 雷装
	AntiAirCraft,			// 防空
	AntiSubmarine,		// 对潜
	AirCraft,					// 搭载
	Radar,						// 索敌
	Speed,					// 航速
	Reload,					// 装填
	Hit,							// 命中
	Avoid,						// 闪避
	Luck,						// 幸运
	Length
}
