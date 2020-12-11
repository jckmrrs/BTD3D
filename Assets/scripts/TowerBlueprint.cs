﻿using System.Collections;
using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public GameObject prefab;
    public GameObject upgradedPrefab;
    public int cost;
    public int unlockAtLevel;
    public int upgradeCost;

    //These variables are set in the shop in unity. 
    public int GetSellAmount()
    {
        return cost / 2;
    }
    

}
