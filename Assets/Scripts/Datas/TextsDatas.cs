using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextsDatas {
	static Dictionary<int, string> dic_texts = new Dictionary<int, string>();

	// Xml 存放目录
	static string str_path;

	public static void Init() {
		str_path = Application.dataPath + "/Datas/SystemTexts.xml";

		List<IntAndString> _cacheList = (List<IntAndString>)XmlSerializeTools.DeserializeXml (str_path, typeof(List<IntAndString>));
		foreach (IntAndString ias in _cacheList) {
			if (dic_texts.ContainsKey (ias.Index))
				throw new UnityException ("Key Repeat");
			else
				dic_texts.Add (ias.Index, ias.Value);
		}
	}

	public static string GetText(int index) {
		return dic_texts [index];
	}
}
