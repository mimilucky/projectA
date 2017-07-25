using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDelegate {
	public delegate void InitUIData();
	public static InitUIData InitUIDataEvent;

	public static void OnInitUIDataEvent() {
		if (InitUIDataEvent != null)
			InitUIDataEvent ();
	}
}
