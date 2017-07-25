using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	void Start () {
		string fileName = "ShipGirlSprites.xml";
		string path = Application.dataPath + "/Datas/Cache/" + fileName;

		EquipsDatas.Init ();
		ShipGirlsDatas.Init ();
		SettingsDatas.Init ();

		Sava (path);
		//Load();
	}

	void Sava(string path) {
		List<IntAndString> list = new List<IntAndString> ();

		IntAndString ias = new IntAndString ();
		ias.Index = 1;
		ias.Value = "sti";

		list.Add (ias);
		list.Add (ias);

		XmlSerializeTools.SerializeXml (path, list);
	}

	void Load() {
		cShipGirls sg = new cShipGirls (2001, 30);
		Debug.Log (sg.LA.LE);
	}
}
