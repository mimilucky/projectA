using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EquipsDatas {
	static Dictionary<int, cEquips> dic_Equips = new Dictionary<int, cEquips> ();

	static string s_Path;

	public static void Init() {
		s_Path = Application.dataPath + "/Datas/";

		Load (s_Path + "Equips.xml");
	}

	static void Load(string path) {
		List<cEquips> _list = (List<cEquips>)XmlSerializeTools.DeserializeXml (path, typeof(List<cEquips>));
		foreach (cEquips e in _list) {
			if (dic_Equips.ContainsKey (e.Index))
				throw new UnityException ("Repeat Key - Equips.xml ");
			else
				dic_Equips.Add (e.Index, e);
		}
	}

	public static cEquips Get(int index) {
		return dic_Equips [index];
	}
}
