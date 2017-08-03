using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour {

	void Start () {
		// 加载Text
		TextsDatas.Init();
		// 加载UI文件
		UIsDatas.Init();

		// 加载数据
		EquipsDatas.Init ();
		ShipGirlsDatas.Init ();

		// 加载设定
		SettingsDatas.Init ();

		// 加载玩家存档
		PlayersDatas.Init ();

		Debug.Log ("Datas Loading Complete!");

		// 实例化UI加载数据
		MyDelegate.OnInitUIDataEvent ();

		CanvasShowOff.Instance.ShowOnlyOne ("BattleCanvas");
	}
}
