﻿using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TowerBlueprint towerToBuild;
    private Node selectedNode;
    public GameObject buildEffect;
    public GameObject sellEffect;
    public NodeUI nodeUI;

    //When the game starts, if there is already a BuildManager instance, there is a message in the console log. 
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("There is already a BuildManager");
            return;
        }
        instance = this;
    }

    public void SelectNode (Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        towerToBuild = null;
        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    //Set the tower we want to build as the tower we give it. 
    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        DeselectNode();
    }


    //This function determins whether the space is free to build on. 
    public bool CanBuild
    {
        get
        {
            return towerToBuild != null;
        }
    }


    //Sets the tower position as the build position and sets the node tower to the given tower.
    //If the player doesnt have enough money, they wont be able to build the tower. 

    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }

    public bool HasMonees
    {
        get
        {
            return PlayerStatus.monees >= towerToBuild.cost;
        }
    }
}
