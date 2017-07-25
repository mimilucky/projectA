using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsDatas {

	static cGameSettings m_GameSettings;

	// Xml 存放目录
	static string str_path;

	public static void Init() {
		str_path = Application.dataPath + "/Datas/";

		LoadGameSettings("GameSettings.xml");
	}

	private static void LoadGameSettings(string fileName) {
		m_GameSettings = (cGameSettings)XmlSerializeTools.DeserializeXml (str_path + fileName, typeof(cGameSettings));
	}

	public static int GetFTeamsLimit() {
		return m_GameSettings.FTeamsLimit;
	}
	public static int GetETeamsLimit() {
		return m_GameSettings.ETeamsLimit;
	}
}
