using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one builmanager");
        }
        instance = this;
    }

    public GameObject BuildEffect;
    public GameObject SellEffect;

    private TurretBlueprint turretToBuild;
    private NodeScript selectedNode;

    public NodeUI NodeUI;


    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.Cost; } }

    public void SelectNode(NodeScript node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        NodeUI.SetTarget(node);
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void DeselectNode()
    {
        selectedNode = null;
        NodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        NodeUI.Hide();
    }

}
