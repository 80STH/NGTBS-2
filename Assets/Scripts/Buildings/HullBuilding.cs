using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullBuilding : BaseBuilding
{
    //public static event EventHandler OnAnyActionPointsChanged;
    //public static event EventHandler OnAnyUnitSpawned;
    //public static event EventHandler OnAnyUnitDead;
    //public static event EventHandler OnAnyUnitPushed;

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddBuildingAtGridPosition(gridPosition, this);

        //TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;

        healthSystem.OnDead += HealthSystem_OnDead;
        //what
        //hullSystem.OnHullDestroyed += HullSystem_OnHullDestroyed;
        //hullSystem.OnGameOver += HullSystem_OnGameOver;
        //shiftSystem.OnPush += ShiftSystem_OnPush;
    }
     
    public void Damage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
        HullSystem.Instance.Damage(damageAmount);
    }

    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        LevelGrid.Instance.RemoveBuildingAtGridPosition(gridPosition, this);

        Destroy(gameObject);
    }

    public override string GetBuildingName()
    {
        return "Hull Building";
    }
}