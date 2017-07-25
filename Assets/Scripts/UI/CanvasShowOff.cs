using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasShowOff : MonoBehaviour {
	public List<GameObject> canvasList;

	public static CanvasShowOff Instance { get; private set; }
	private GraphicRaycaster m_gr;
	private List<GameObject> m_Opened;
	private Canvas m_cv;

	void Awake() {
		Instance = this;

		m_Opened = new List<GameObject> ();
	}
	void OnDestroy() {
		if (Instance != null)
			Instance = null;
	}

	// 仅仅显示单一界面(其他全部隐藏)
	public void ShowOnlyOne(string Name) {
		m_Opened.Clear ();
		foreach (GameObject go in canvasList) {
			if (go.name != Name) {
				// 隐藏
				go.layer = 8;
				ShowHideGRay (go, false, 0);
			} else {
				// 如果列表里没有, 则添加进去.
				if (!m_Opened.Contains (go))
					m_Opened.Add (go);
				
				// 显示
				go.layer = 5;
				ShowHideGRay (go, true, m_Opened.Count);
			}
		}
	}

	// 在当前显示界面上附加一个界面(不隐藏, 但是屏蔽射线)
	public void ShowAdd(string Name) {
		foreach (GameObject go in canvasList) {
			if (go.name != Name) {
				ShowHideGRay (go, false, 0);
				continue;
			}
			
			m_Opened.Add (go);
			go.layer = 5;
			ShowHideGRay (go, true, m_Opened.Count);
		}

		/*foreach (GameObject go in canvasList) {
			if (go.layer == 5) {
				ShowHideGRay (go, false, 0);
			}
			if (go.name != Name) {
				continue;
			} else {
				go.layer = 5;
				ShowHideGRay (go, true, 1);
			}
		}*/
	}

	// 关闭在当前显示界面上附加的一个界面(隐藏附加, 屏蔽附加射线, 恢复当前层射线)
	public void HideAdd(string Name) {
		foreach (GameObject go in canvasList) {
			if (go.layer != 5)
				continue;
			
			if (go.name != Name) {
				ShowHideGRay (go, true, 1);
			} else {
				ShowHideGRay (go, false, 0);
				go.layer = 8;
			}
		}
	}
	private void ShowHideGRay(GameObject go, bool showHide, int sortingOrder) {
		m_gr = go.GetComponent<GraphicRaycaster> ();
		m_gr.enabled = showHide;
		m_cv = go.GetComponent<Canvas> ();
		m_cv.sortingOrder = sortingOrder;
	}
}
