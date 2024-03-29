using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public TurretBlueprint StandardTurret;
    public TurretBlueprint MissileLauncher;
    public TurretBlueprint LaserBeamer;
    public TurretBlueprint Bomber;

    BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(StandardTurret);
    }

    public void SelectMissleLauncherTurret()
    {
        buildManager.SelectTurretToBuild(MissileLauncher);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(LaserBeamer);
    }

        public void SelectBomber()
    {
        buildManager.SelectTurretToBuild(Bomber);
    }
}
