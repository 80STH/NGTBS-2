using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainEffectManager : MonoBehaviour
{
    //uncomment if i want to add proper visual
    //public event EventHandler OnDead;
    //public event EventHandler OnDamaged;

    //public event EventHandler<OnAnyTerrainEffectAppliedEventArgs> OnAnyTerrainEffectApplied;

    //public class OnAnyTerrainEffectAppliedEventArgs : EventArgs
    //{
    //    public string effectName;
    //    public GridPosition gridPosition;
    //}

    private List<TerrainEffect> terrainEffectList;

    private void Awake()
    {
        terrainEffectList = new List<TerrainEffect>();
    }

    private void Start()
    {
        TerrainEffect.OnAnyTerrainEffectSpawned += TerrainEffect_OnAnyTerrainEffectSpawned;
        TerrainEffect.OnAnyTerrainEffectRemoved += TerrainEffect_OnAnyTerrainEffectRemoved;
    }
    public void ApplyTerrainEffect(string typeOfTerrainEffect, GridPosition gridPosition)
    {
        if (typeOfTerrainEffect == "fire")
        {
            FireTerrainEffect fireTerrainEffect = LevelGrid.Instance.AddComponent<FireTerrainEffect>();
            LevelGrid.Instance.AddTerrainEffectAtGridPosition(gridPosition, fireTerrainEffect);
            terrainEffectList.Add(fireTerrainEffect);
        }
    }

    public void ClearTerrainEffect(TerrainEffect terrainEffect)
    {
        if (terrainEffectList.Count > 0)
        {
            terrainEffectList.Remove(terrainEffect);
        }
    }

    public List<TerrainEffect> GetTerrainEffectList()
    {
        return terrainEffectList;
    }

    private void TerrainEffect_OnAnyTerrainEffectSpawned(object sender, EventArgs e)
    {
        TerrainEffect terrainEffect = sender as TerrainEffect;

        terrainEffectList.Add(terrainEffect);
    }

    private void TerrainEffect_OnAnyTerrainEffectRemoved(object sender, EventArgs e)
    {
        TerrainEffect terrainEffect = sender as TerrainEffect;

        terrainEffectList.Remove(terrainEffect);
    }

}
