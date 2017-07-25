using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayersDatas {
	static int m_CurIndex;

	// 玩家存档列表
	static Dictionary<int, cPlayers> dic_Players = new Dictionary<int, cPlayers>();

	// 玩家经验列表
	// 跟舰娘等级经验同一个列表.

	// Xml 存放目录
	static string str_path;

	public static void Init() {
		str_path = Application.dataPath + "/Datas/";

		m_CurIndex = 1;

		LoadSave ("PlayerSaves.xml");

		InitPlayerGirlsDatas ();
	}

	// 保存存档
	public static void Save() {
		List<cPlayers> _cacheList = new List<cPlayers> ();
		foreach (KeyValuePair<int, cPlayers> kvp in dic_Players) {
			_cacheList.Add (kvp.Value);
		}
		XmlSerializeTools.SerializeXml (str_path + "PlayerSaves1.xml", _cacheList);
	}

	// 载入存档
	private static void LoadSave(string fileName) {
		List<cPlayers> _cacheList = (List<cPlayers>)XmlSerializeTools.DeserializeXml (str_path + fileName, typeof(List<cPlayers>));

		foreach (cPlayers p in _cacheList) {
			if (dic_Players.ContainsKey (p.Index))
				throw new UnityException ("Key Repeat");
			else
				dic_Players.Add (p.Index, p);
		}
	}

	// 初始化玩家数据 - 舰娘
	private static void InitPlayerGirlsDatas() {
		foreach (KeyValuePair<int, cPlayers> kvp in dic_Players) {
			foreach (cPCShipGirls pcsg in kvp.Value.GirlsSaves) {
				pcsg.Levels.LE = ShipGirlsDatas.GetLevelExp (pcsg.Levels.L);
				kvp.Value.AddGirls (pcsg);
			}
		}
	}

	public static string GetName() {
		return dic_Players [m_CurIndex].Name;
	}
	public static int GetRank() {
		return (int)dic_Players[m_CurIndex].Rank;
	}
	public static cLevelA GetLevel() {
		return dic_Players [m_CurIndex].Level;
	}
	public static cMoneys GetMoneys() {
		return dic_Players [m_CurIndex].Moneys;
	}
	public static cTeams GetTeams() {
		return dic_Players [m_CurIndex].Teams;
	}
	public static cShipGirls GetShipGirls(int index) {
		foreach(cShipGirls sg in dic_Players [m_CurIndex].Girls)
			if(sg.Index == index)
				return sg;
		return null;
	}
	public static cPlayers Get() {
		return dic_Players [m_CurIndex];
	}
}
