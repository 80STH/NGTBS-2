using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSystem : MonoBehaviour
{
    public event EventHandler OnPush;
    //public event EventHandler OnDamaged;


    //[SerializeField] private int health = 100;
    //private int healthMax;


    //private void Awake()
    //{
    //    healthMax = health;
    //}
    private GridPosition gridPosition;
    private GridPosition newGridPosition;
    public GridPosition Shift(Unit unit, string pushDirection) /*(int pushDistance)*/
    {
        newGridPosition = unit.GetGridPosition();
        switch (pushDirection)
        {
            case "LeftDown":
                newGridPosition = gridPosition;
                break;
            case "Left":
                newGridPosition.x -= 1;
                break;
            case "LeftUp":
                newGridPosition = gridPosition;
                break;
            case "RightUp":
                newGridPosition = gridPosition;
                break;
            case "Right":
                newGridPosition.x += 1;
                break;
            case "RightDown":
                newGridPosition = gridPosition;
                break;
            default:
                break;
        }
        //health -= damageAmount;

        //if (health < 0)
        //{
        //    health = 0;
        //}

        //OnDamaged?.Invoke(this, EventArgs.Empty);

        //if (health == 0)
        //{
        //    Die();
        //}
        return newGridPosition;
    }

    //private void Die()
    //{
    //    OnDead?.Invoke(this, EventArgs.Empty);
    //}

    //public float GetHealthNormalized()
    //{
    //    return (float)health / healthMax;
    //}

    private void Update()
    {
        if (gridPosition != null)
        {
            OnPush?.Invoke(this, EventArgs.Empty);
        }
    }
}
