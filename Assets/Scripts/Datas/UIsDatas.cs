using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIsDatas {
	// 立绘
	static Dictionary <int, Sprite> dic_GirlSprite = new Dictionary<int, Sprite> ();
	// 铭牌
	static Dictionary<int, Sprite> dic_GirlNamePlate = new Dictionary<int, Sprite> ();
	// 头像
	static Dictionary<int, Sprite> dic_GirlAvatar = new Dictionary<int, Sprite>();
	// 装备图标
	static Dictionary <int, Sprite> dic_EquipIcon = new Dictionary<int, Sprite> ();
	// 界面图标
	static Dictionary<int, Sprite> dic_UIIcon = new Dictionary<int, Sprite> ();

	// Xml 存放目录
	static string str_path;

	// Icon 存放目录
	static string icon_path;

	public static void Init() {
		str_path = Application.dataPath + "/Datas/";
		LoadSprite (dic_GirlSprite, "Girls_Sprites.xml", "Sprites/Girls/");
		LoadSprite (dic_EquipIcon, "Icons_Equips.xml", "Icons/Equips/");
		//LoadSprite (dic_UIIcon, "Icons_UI.xml", "Icons/UIs/");
	}

	private static void LoadSprite(Dictionary<int, Sprite> dic, string xmlFileName, string dicName) {
		List<IntAndString> _cacheList = (List<IntAndString>)XmlSerializeTools.DeserializeXml (str_path + xmlFileName, typeof(List<IntAndString>));

		foreach (IntAndString ias in _cacheList) {
			if (dic.ContainsKey (ias.Index)) {
				throw new UnityException ("Key Repeat");
			} else {
				#if UNITY_EDITOR_WIN
				ResourceRequest rp = Resources.LoadAsync(dicName + ias.Value, typeof(Sprite));
				dic.Add(ias.Index, (Sprite)rp.asset);
				#elif UNITY_STANDALONE_WIN
				AssetBundle ab = AssetBundle.LoadFromFile(sprite_path + dicName + kvp.Value);
				foreach(Object o in ab.LoadAllAssets())
				dic.Add(kvp.Key, (Sprite)o);
				ab.Unload(false);
				#endif
			}
		}
	}
	public static Sprite GetGirlSprite(int index) {
		return dic_GirlSprite [index];
	}
	public static Sprite GetGirlNamePlate(int index) {
		return dic_GirlNamePlate [index];
	}
	public static Sprite GetGirlAvatar(int index) {
		return dic_GirlAvatar [index];
	}
	public static Sprite GetEquipIcon(int index) {
		return dic_EquipIcon [index];
	}
	public static Sprite GetUIIcon(int index) {
		return dic_UIIcon [index];
	}
}
