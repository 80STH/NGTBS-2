using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //public static event EventHandler OnAnyActionPointsChanged;
    //public static event EventHandler OnAnyUnitSpawned;
    //public static event EventHandler OnAnyUnitDead;
    //public static event EventHandler OnAnyUnitPushed;

    private GridPosition gridPosition;
    private HealthSystem healthSystem;
    private HullSystem hullSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        hullSystem = GetComponent<HullSystem>();
    }

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
    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }

    public Vector3 GetWorldPosition()
    {
        return transform.position;
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

    public float GetHealthNormalized()
    {
        return healthSystem.GetHealthNormalized();
    }

}