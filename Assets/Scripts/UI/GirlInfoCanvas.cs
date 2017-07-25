using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlInfoCanvas : MonoBehaviour {
	public static GirlInfoCanvas Instance { get; private set; }

	public Image img_GirlSprite;

	public Text text_ShipType;
	public Text text_Name;
	public Text text_Descript;

	public Text text_Level;
	public Text text_Exp;
	public RectTransform rt_ExpBarBg;
	public RectTransform rt_ExpBarD;

	public List<Text> text_TA;
	public List<taGroups> ta_Groups;
	[Serializable]
	public class taGroups
	{
		public Image icon;
		public Text value;
	}

	public List<rtGroups> rt_Groups;
	[Serializable]
	public class rtGroups {
		public Button btn;
		public RectTransform box;
	}

	public List<eqGroups> eq_Groups;
	[Serializable]
	public class eqGroups
	{
		public Button btn;
		public Text typeName;
		public Image Icon;
		public RectTransform Useable;
	}

	public Text text_dmg;
	public Text text_dmgCount;
	public Text text_Speed;
	public Text text_dmgType;
	public Text text_lockType;
	public Text text_atkType;
	public Text text_Range;
	public Text text_Offset;
	public Text text_specialEffcet;
	public Text text_equipsName;
	public Text text_equipsDescript;

	private int m_equipsLength;

	private cShipGirls m_ShipGirls;
	private int m_sgIndex;

	void Awake() {
		Instance = this;
	}
	void OnDestroy() {
		if (Instance != null)
			Instance = null;
	}

	public void InitFromPlayersDatas(int index) {
		if (m_sgIndex == index)
			return;
		
		// 从存档获取指定ID的舰娘信息.
		m_ShipGirls = PlayersDatas.GetShipGirls (index);
		m_sgIndex = index;
		Init ();
	}
	public void InitFromBaseDatas(int index) {
		if (m_sgIndex == index)
			return;
		// 从基础文件获取指定ID的舰娘信息.
		m_ShipGirls = ShipGirlsDatas.Get (index);
		m_sgIndex = index;
		Init ();
	}

	public void DisplayBox(RectTransform g) {
		for (int i = 0; i < rt_Groups.Count; i++) {
			if (rt_Groups [i].box == g) {
				rt_Groups [i].btn.interactable = false;
				rt_Groups [i].box.localPosition = new Vector3 (0, -40);
			} else {
				rt_Groups [i].btn.interactable = true;
				rt_Groups [i].box.localPosition = new Vector3 (500, -40);
			}
		}
	}

	public void DisplayEquipsAtt(Button b) {
		for (int i = 0; i < m_equipsLength; i++) {
			if (eq_Groups [i].btn == b) {
				eq_Groups [i].btn.interactable = false;

				UpdateEquipsInfo (m_ShipGirls.E [i].E);
			} else {
				eq_Groups [i].btn.interactable = true;
			}
		}
	}

	public void HideCanvas() {
		CanvasShowOff.Instance.HideAdd (gameObject.name);
	}

	private void Init() {
		// 立绘
		Sprite s = UIsDatas.GetGirlSprite (m_ShipGirls.Index);
		img_GirlSprite.sprite = s;
		img_GirlSprite.SetNativeSize ();

		InitAttInfo ();
		// 获得指定ID舰娘的装备槽数量
		m_equipsLength = ShipGirlsDatas.GetDefaultEquipsLength (m_ShipGirls.Index);
		InitEquipsInfo ();
	}

	private void InitAttInfo() {
		// 名字等
		text_ShipType.text = TextsDatas.GetText ((int)m_ShipGirls.ST);

		text_Name.text = m_ShipGirls.TI.Name;
		text_Descript.text = m_ShipGirls.TI.Descript;

		if (m_ShipGirls.LA.L > 0)
			text_Level.text = m_ShipGirls.LA.L.ToString ();
		else if (m_ShipGirls.LA.L == 0)
			text_Level.text = TextsDatas.GetText (10010);
		text_Exp.text = m_ShipGirls.LA.CE + " / " + m_ShipGirls.LA.LE;

		float i = rt_ExpBarBg.sizeDelta.x;
		float per = (float)m_ShipGirls.LA.CE / m_ShipGirls.LA.LE;

		if (per >= 1)
			rt_ExpBarD.sizeDelta = new Vector2 (i, rt_ExpBarD.sizeDelta.y);
		else
			rt_ExpBarD.sizeDelta = new Vector2 (per * i, rt_ExpBarD.sizeDelta.y);

		// 舰娘属性
		/*for (int i1 = 0; i1 < text_TA.Count; i1++)
			text_TA [i1].text = m_ShipGirls.TA [i1].V.ToString ();*/
		for (int i1 = 0; i1 < ta_Groups.Count; i1++) {
			ta_Groups [i1].value.text = m_ShipGirls.TA [i1].V.ToString ();
		}
	}

	private void InitEquipsInfo() {
		for (int i = 0; i < eq_Groups.Count; i++) {
			// 移开屏蔽层
			eq_Groups [i].Useable.localPosition = new Vector3 (500, 0);

			// 屏蔽当前舰娘没有的装备位
			if (i > m_equipsLength - 1) {
				// 移回不可用屏蔽层
				eq_Groups [i].Useable.localPosition = Vector3.zero;
				// 把之前的装备图标隐藏
				eq_Groups [i].Icon.color = Color.clear;
			} else {
				// 修改类型名
				eq_Groups[i].typeName.text = TextsDatas.GetText(100 + (int)m_ShipGirls.E[i].T);
				// 修改显示的装备图标
				eq_Groups[i].Icon.sprite = UIsDatas.GetEquipIcon(m_ShipGirls.E[i].Index);
			}
		}
		UpdateEquipsInfo (m_ShipGirls.E [0].E);
	}

	private void UpdateEquipsInfo(cEquips e) {
		// 显示第一个装备数值
		text_dmg.text = e.FA.Dmg.ToString();
		text_dmgCount.text = e.FA.Count.ToString();
		text_Speed.text = e.FA.Speed.ToString();
		text_dmgType.text = TextsDatas.GetText(520 + (int)e.FA.DmgType);
		text_lockType.text = TextsDatas.GetText(500 + (int)e.FA.LockType);
		text_atkType.text = TextsDatas.GetText(510 + (int)e.FA.AtkType);
		text_Range.text = e.FA.Range.ToString();
		text_Offset.text = e.FA.OffSet.ToString();
		// 特殊效果说明 - 暂无
		text_specialEffcet.text = e.TI.Name;
		// 装备名字
		text_equipsName.text = e.TI.Name;
		// 介绍
		text_equipsDescript.text = e.TI.Descript;
	}
}
