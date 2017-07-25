using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShipGirlsDatas {
	// 舰娘数据列表
	static Dictionary<int, cShipGirls> dic_ShipGirls = new Dictionary<int, cShipGirls>();

	// 舰娘等级经验列表
	static Dictionary<int, int> dic_LevelExp = new Dictionary<int, int>();

	// Xml 存放目录
	static string str_path;

	public static void Init() {
		str_path = Application.dataPath + "/Datas/";

		LoadShipGirls ("ShipGirls.xml");
		LoadIntAndInt (dic_LevelExp, "LevelExp.xml");
	}
	private static void LoadShipGirls(string fileName) {
		List<cShipGirls> _cacheList = (List<cShipGirls>)XmlSerializeTools.DeserializeXml (str_path + fileName, typeof(List<cShipGirls>));

		foreach (cShipGirls sg in _cacheList) {
			if (dic_ShipGirls.ContainsKey (sg.Index))
				throw new UnityException ("Key Repeat");
			else
				dic_ShipGirls.Add (sg.Index, sg);
		}
	}

	// 载入文本 Int类型
	private static void LoadIntAndInt(Dictionary<int, int> dic , string fileName) {
		List<IntAndInt> _cacheList = (List<IntAndInt>)XmlSerializeTools.DeserializeXml (str_path + fileName, typeof(List<IntAndInt>));

		foreach (IntAndInt iai in _cacheList) {
			if (dic.ContainsKey (iai.Index1))
				throw new UnityException ("Key Repeat");
			else
				dic.Add (iai.Index1, iai.Index2);
		}
	}

	public static cShipGirls Get(int index) {
		return dic_ShipGirls [index];
	}
	public static cES[] GetDefaultEquips(int index) {
		return dic_ShipGirls [index].E;
	}
	public static int GetDefaultEquipsLength(int index) {
		return dic_ShipGirls [index].E.Length;
	}

	// 获取舰娘等级上限
	public static int GetLevelMax() {
		return dic_LevelExp.Count - 1;
	}
	// 获取舰娘升级所需经验数值
	public static int GetLevelExp(int index) {
		return dic_LevelExp [index];
	}

	public static eST GetShipType(int index) {
		return dic_ShipGirls [index].ST;
	}
}
