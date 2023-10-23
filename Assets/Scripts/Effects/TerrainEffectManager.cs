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

    public static TerrainEffectManager Instance { get; private set; }

    [SerializeField] private TerrainEffect[] TerrainEffectPrefab;


    private List<TerrainEffect> terrainEffectList;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one TerrainEffectManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

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
            TerrainEffect fireTerrainEffect = TerrainEffectPrefab[0];
            Vector3 position = LevelGrid.Instance.GetWorldPosition(gridPosition);
            LevelGrid.Instance.AddTerrainEffectAtGridPosition(gridPosition, fireTerrainEffect);

            //subject to remove
            Instantiate(fireTerrainEffect, position, transform.rotation * Quaternion.Euler(-90f, 0f, 0f));
            //

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
