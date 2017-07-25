using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DormRoomGirlInfo : MonoBehaviour {
	public DormRoomCanvas dormRoomCanvas;

	public Image girlNamePlate;
	public Image girlHappy;
	public Image girlTrans;
	public Image girMarry;

	public Button girlFight;
	public Button girlSup;

	public int m_girlIndex;

	public void Init(int index) {
		m_girlIndex = index;

		// 更新铭牌图片
		//girlNamePlate.sprite = UIsDatas.GetGirlNamePlate(m_girlIndex);
		// 更新心情状态图标
		//girlNamePlate.sprite = UIsDatas.GetUIIcon(m_girlIndex);
		// 更新改造阶段图标
		//girlNamePlate.sprite = UIsDatas.GetUIIcon(m_girlIndex);
		// 更新结婚状态图标
		//girlNamePlate.sprite = UIsDatas.GetUIIcon(m_girlIndex);

		// 屏蔽非对应船型的出击按钮
		eST shipType = ShipGirlsDatas.GetShipType (m_girlIndex);
		if (shipType == eST.CV || shipType == eST.CVL) {
			girlFight.interactable = false;
		} else {
			girlSup.interactable = false;
		}
	}

	public void ShowGirlInfo() {
		GirlInfoCanvas.Instance.InitFromPlayersDatas (m_girlIndex);
		CanvasShowOff.Instance.ShowAdd ("GirlInfoCanvas");
	}

	public void SetGirlFight() {
		dormRoomCanvas.SetGirlFight (m_girlIndex);
	}
	public void SetGirlSup() {
		dormRoomCanvas.SetGirlSup (m_girlIndex);
	}
}
