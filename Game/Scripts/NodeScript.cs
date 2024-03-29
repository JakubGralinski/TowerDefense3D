using UnityEngine;
using UnityEngine.EventSystems;

public class NodeScript : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Color notEnoughMoneyColor;

    public Vector3 PosOffSet;

    [HideInInspector]
    public GameObject Turret;
    [HideInInspector]
    public TurretBlueprint TurretBlueprint;
    [HideInInspector]
    public bool IsUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        // Checking if there's a turret on the node
        if (Turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }


        if (!buildManager.CanBuild)
            return;

       // buildManager.BuildTurretOn(this);

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.Cost)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        PlayerStats.Money -= blueprint.Cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.Prefab, GetBuildPos(), Quaternion.identity);
        Turret = _turret;

        TurretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, GetBuildPos(), Quaternion.identity);

        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < TurretBlueprint.UpgradeCost)
        {
            Debug.Log("Not enough gold to upgrade!");
            return;
        }

        PlayerStats.Money -= TurretBlueprint.UpgradeCost;

        //Destroying the Old non upgraded turret
        Destroy(Turret);

        //Build the upgraded 
        GameObject _turret = (GameObject)Instantiate(TurretBlueprint.UpgradedPrefab, GetBuildPos(), Quaternion.identity);
        Turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, GetBuildPos(), Quaternion.identity);

        Destroy(effect, 5f);

        IsUpgraded = true;

        Debug.Log("Turret upgraded! Money left: " + PlayerStats.Money);
    }

    public void SellTurret()
    {
        PlayerStats.Money += TurretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.SellEffect, GetBuildPos(), Quaternion.identity);

        Destroy(effect, 5f);
        Destroy(Turret);

        TurretBlueprint = null;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
  
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPos()
    {
        return transform.position + PosOffSet;
    }
}
