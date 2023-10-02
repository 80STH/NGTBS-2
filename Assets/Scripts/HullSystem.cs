using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HullSystem : MonoBehaviour
{
    public event EventHandler OnGameOver;
    public event EventHandler OnHullChanged;
    public event EventHandler OnHullDestroyed;

    public static HullSystem Instance { get; private set; }

    [SerializeField] private int hull = 7;
    private int hullMax;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one HullSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        hullMax = hull;
    }

    public void Damage(int damageAmount)
    {
        hull -= damageAmount;

        if (hull < 0)
        {
            hull = 0;
        }

        OnHullChanged?.Invoke(this, EventArgs.Empty);

        if (hull == 0)
        {
            GameOver();
        }
    }

    private void GameOver() 
    {
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    public float GetHull()
    {
        return hull;
    }
}
