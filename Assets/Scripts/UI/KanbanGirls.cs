using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanbanGirls : MonoBehaviour {
	public Image Image_KanbanGirl;

	void Start() {
		MyDelegate.InitUIDataEvent += Init;
	}

	void Init() {
		int girlSpriteIndex = PlayersDatas.GetTeams ().Fight [0].MainGirl;

		Sprite s = UIsDatas.GetGirlSprite (girlSpriteIndex);
		Image_KanbanGirl.sprite = s;
		Image_KanbanGirl.SetNativeSize ();

		Debug.Log ("KanbanGirls Load Complete");
	}

	public void ShowKanbanGirlInfo() {
		GirlInfoCanvas.Instance.InitFromPlayersDatas (PlayersDatas.GetTeams ().Fight [0].MainGirl);
		CanvasShowOff.Instance.ShowAdd ("GirlInfoCanvas");
	}
}
