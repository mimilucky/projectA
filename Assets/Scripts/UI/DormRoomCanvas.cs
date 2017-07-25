using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DormRoomCanvas : MonoBehaviour {
	public Image fightIcon;
	public Image supIcon;

	public Transform list_Parent;
	public DormRoomGirlInfo list_object;

	private cPlayers m_pc;
	private int m_girlCount;
	private List<DormRoomGirlInfo> m_sortList;

	void Start() {
		MyDelegate.InitUIDataEvent += Init;
	}

	public void Init() {
		if (m_pc == null) {
			m_pc = PlayersDatas.Get ();

			UpdateIcon (fightIcon.sprite, m_pc.Teams.Fight [0].MainGirl);
			UpdateIcon(supIcon.sprite, m_pc.Teams.Fight[0].SurppotGirl);

			m_sortList = new List<DormRoomGirlInfo> ();
		}
		// 生成舰娘列表
		int i = m_pc.GirlsSaves.Count;
		if (m_girlCount != i) {
			for (int i1 = 0; i1 < i; i1++) {
				GameObject go = GameObject.Instantiate (list_object.gameObject, list_Parent);
				DormRoomGirlInfo _cache = go.GetComponent<DormRoomGirlInfo> ();
				_cache.Init (m_pc.GirlsSaves [i1].Index);

				if (!m_sortList.Contains (_cache))
					m_sortList.Add (_cache);
			}
			m_girlCount = i;

			SortGirlList ();
		}
	}
	private void SortGirlList() {
		m_sortList.Sort((x, y) => {
			int r;
			if(x.m_girlIndex.CompareTo(y.m_girlIndex) >0)
				r =1;
			else
				r = -1;
			return r;
		});
		for (int i = 0; i < m_sortList.Count; i++) {
			m_sortList [i].gameObject.SetActive (true);
		}
	}

	// 设置主力
	public void SetGirlFight(int index) {
		// 检测当前主力是否和要设置的一样, 是的话就弹出提示
		if (m_pc.Teams.Fight [0].MainGirl == index) {
			// 弹出"当前舰娘已是主力"提示

			return;
		}
		m_pc.Teams.Fight [0].MainGirl = index;
		// 更新 上方显示
		UpdateIcon(fightIcon.sprite, index);

		// 更新主界面看板娘.
		// UpdateKanaban(index);
	}
	// 设置支援
	public void SetGirlSup(int index) {
		// 检测当前支援是否和要设置的一样, 是的话就弹出提示
		if (m_pc.Teams.Fight [0].SurppotGirl == index) {
			// 弹出"当前舰娘已是支援"提示

			return;
		}
		m_pc.Teams.Fight [0].SurppotGirl = index;
		// 更新 上方显示
		UpdateIcon(supIcon.sprite, index);
	}
	private void UpdateIcon(Sprite spr, int index) {
	//	spr = UIsDatas.GetGirlAvatar (index);
	}

	public void HideCanvas(bool b) {
		if(b)
			CanvasShowOff.Instance.HideAdd (gameObject.name);
		else
			CanvasShowOff.Instance.ShowAdd (gameObject.name);
	}
}
