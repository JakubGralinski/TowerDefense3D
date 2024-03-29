using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;

    public Text UpgradeCost;
    public Button UpgradeButton;

    public Text SellAmount;

    private NodeScript target;

    public void SetTarget(NodeScript _target)
    {
        target = _target;

        transform.position = target.GetBuildPos();

        
        if (!target.IsUpgraded)
        {
            UpgradeCost.text = "$" + target.TurretBlueprint.UpgradeCost;
            UpgradeButton.interactable = true;
        }
        else
        {
            UpgradeCost.text = "DONE";
            UpgradeButton.interactable = false;
        }

        SellAmount.text = "$" + target.TurretBlueprint.GetSellAmount();

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }
    
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
