using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatesBox : MonoBehaviour {
	public Text pcName;
	public Text pcLevel;
	public Text pcRank;

	public Text pcMoney_Oil;
	public Text pcMoney_Bullet;
	public Text pcMoney_Steel;
	public Text pcMoney_Aluminum;

	void Start() {
		MyDelegate.InitUIDataEvent += Init;
	}

	void OnDestroy() {
		MyDelegate.InitUIDataEvent -= Init;
	}

	void Init() {
		// 名字 - 赋值
		pcName.text = PlayersDatas.GetName ();
		// 等级 - 引用
		cLevelA LA = PlayersDatas.GetLevel ();
		if (LA.L > 0)
			pcLevel.text = LA.L.ToString ();
		else if (LA.L == 0)
			pcLevel.text = TextsDatas.GetText (10010);
		// 同上 - 赋值
		pcRank.text = TextsDatas.GetText(1000 + PlayersDatas.GetRank());

		// 资源 - 引用
		cMoneys m = PlayersDatas.GetMoneys ();
		pcMoney_Oil.text = m.O.ToString();
		pcMoney_Bullet.text = m.B.ToString();
		pcMoney_Steel.text = m.S.ToString();
		pcMoney_Aluminum.text = m.A.ToString();

		Debug.Log ("States Load Complete");
	}
}
