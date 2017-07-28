using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    cTeams ally = PlayersDatas.GetTeams();
    public GameObject AllyPanel;
    public GameObject EnnemiesPanel;
    public GameObject ship;
    private void Start()
    {
        foreach (cNavis obj in ally.Expedition)
        {
            GameObject temp = Instantiate(ship);
            temp.transform.SetParent(AllyPanel.transform);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
