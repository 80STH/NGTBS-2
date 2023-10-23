using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainEffect : MonoBehaviour
{
    public static event EventHandler OnAnyTerrainEffectSpawned;
    public static event EventHandler OnAnyTerrainEffectRemoved;


    //terrain means on the ground
    private bool IsPermanent;

    private GridPosition gridPosition;

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }

    public Vector3 GetWorldPosition()
    {
        return transform.position;
    }
}
