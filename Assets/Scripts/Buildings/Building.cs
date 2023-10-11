using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected GridPosition gridPosition;
    protected HealthSystem healthSystem;

    protected virtual void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    public abstract string GetBuildingName();
    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }

    public Vector3 GetWorldPosition()
    {
        return transform.position;
    }

    //public virtual void Damage(int damageAmount)
    //{
    //    healthSystem.Damage(damageAmount);
    //}

    //private void HealthSystem_OnDead(object sender, EventArgs e)
    //{
    //    LevelGrid.Instance.RemoveBuildingAtGridPosition(gridPosition, this);

    //    Destroy(gameObject);
    //}

    public void Damage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
    }

    public float GetHealthNormalized()
    {
        return healthSystem.GetHealthNormalized();
    }
}