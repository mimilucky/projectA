using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    cTeams ally;
    public GameObject AllyPanel;
    public GameObject EnnemiesPanel;
    public GameObject Ship;
    private void Start()
    {
        Debug.Log("building combat scene");
        ally = PlayersDatas.GetTeams();

        //制造友军
        for (int i = 0; i < ally.Fight.Length; i++)
        {
            GameObject temp = Instantiate(Ship, AllyPanel.transform);
            Image logo = temp.GetComponentInChildren<Image>();
            logo.sprite = UIsDatas.GetGirlSprite(ally.Fight[i].MainGirl);
            cShipGirls ship = ShipGirlsDatas.Get(ally.Fight[i].MainGirl);
            BattleStats.AllyHP[i] = 300;
        }
        

        //制造敌军
        for (int i = 0; i < 1; i++)
        {
            GameObject temp = Instantiate(Ship, EnnemiesPanel.transform);
            Image logo = temp.GetComponentInChildren<Image>();
            logo.sprite = UIsDatas.GetEnnemySprite(1);
        }


    }

    private void FixedUpdate()
    {
        BattleStats.time();
    }
}
