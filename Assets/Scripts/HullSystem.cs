using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullSystem : MonoBehaviour
{
    public event EventHandler OnGameOver;
    public event EventHandler OnHullDamaged;


    [SerializeField] private int hull = 7;
    private int hullMax;


    private void Awake()
    {
        hullMax = hull;
    }

    public void Damage(int damageAmount)
    {
        hull -= damageAmount;

        if (hull < 0)
        {
            hull = 0;
        }

        OnHullDamaged?.Invoke(this, EventArgs.Empty);

        if (hull == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    public float GetHullNormalized()
    {
        return (float)hull / hullMax;
    }
}
