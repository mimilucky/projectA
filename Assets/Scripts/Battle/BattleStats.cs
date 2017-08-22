using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BattleStats{
    
    static float fixedtime = (float)0.02;
    public static int[] AllyID;
    public static float[] AllyHP;
    public static float[] EnnemyHP;
    public static float[] InitialNormalCD;          //普攻初始cd
    public static float[] NormalCD;                 //普攻cd
    public static bool auto = false;
    public static void init()
    {
        AllyID = new int[3];
        AllyHP = new float[3];
        InitialNormalCD = new float[6];
        for (int i = 0; i < 3; i++)
        {
            //InitialCD[i] = ShipGirlsDatas.Get(AllyID[i]).TI;
        }


        NormalCD = new float[6];

    }

    public static void time()
    {
        
        for (int i = 0; i < NormalCD.Length; i++)
        {
            try
            {
                NormalCD[i] -= fixedtime;
                if (NormalCD[i]==0)
                {
                    Shoot(i);
                    NormalCD[i] = InitialNormalCD[i];
                }
            }
            catch (System.Exception)
            {

            }
            
        }
    }

    public static void Shoot(int index)
    {

    }




}
