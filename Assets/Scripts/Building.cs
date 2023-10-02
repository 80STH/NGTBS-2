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
        //hullSystem.OnHullChanged += HullSystem_OnHullChanged;
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

    //public bool IsEnemy()
    //{
    //    return isEnemy;
    //}

    public void Damage(int damageAmount)
    {
        hullSystem.Damage(damageAmount);
        healthSystem.Damage(damageAmount);
    }

    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        LevelGrid.Instance.RemoveBuildingAtGridPosition(gridPosition, this);

        Destroy(gameObject);

        //temporary!!!
        hullSystem.Damage(1);
        Debug.Log(hullSystem.GetHull());

        //OnAnyBuildingDestroyed?.Invoke(this, EventArgs.Empty);
    }

    private void HullSystem_OnHullChanged(object sender, EventArgs e)
    {
        
    }

    private void HullSystem_OnGameOver(object sender, EventArgs e)
    {
        
    }

    public float GetHealthNormalized()
    {
        return healthSystem.GetHealthNormalized();
    }

}