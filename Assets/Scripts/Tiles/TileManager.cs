using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileManager : MonoBehaviour
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

    public static TileManager Instance { get; private set; }

    [SerializeField] private Tile[] TilePrefab;


    private List<Tile> tileList;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one TileManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        tileList = new List<Tile>();
    }

    private void Start()
    {
        //Tile.OnAnyTileEffectSpawned += Tile_OnAnyTileEffectSpawned;
        //Tile.OnAnyTileEffectRemoved += Tile_OnAnyTileEffectRemoved;
    }
    public void ApplyTile(string typeOfTerrainEffect, GridPosition gridPosition)
    {
        if (typeOfTerrainEffect == "fire")
        {
            //TerrainEffect fireTerrainEffect = TerrainEffectPrefab[0];
            //Vector3 position = LevelGrid.Instance.GetWorldPosition(gridPosition);
            //LevelGrid.Instance.AddTerrainEffectAtGridPosition(gridPosition, fireTerrainEffect);

            ////subject to remove
            //Instantiate(fireTerrainEffect, position, transform.rotation * Quaternion.Euler(-90f, 0f, 0f));
            ////

            //terrainEffectList.Add(fireTerrainEffect);
        }
    }

    public void ClearTiles(Tile tile)
    {
        if (tileList.Count > 0)
        {
            tileList.Remove(tile);
        }
    }

    public List<Tile> GetTileList()
    {
        return tileList;
    }

    private void TerrainEffect_OnAnyTerrainEffectSpawned(object sender, EventArgs e)
    {
        Tile tile = sender as Tile;

        tileList.Add(tile);
    }

    private void TerrainEffect_OnAnyTerrainEffectRemoved(object sender, EventArgs e)
    {
        Tile tile = sender as Tile;

        tileList.Remove(tile);
    }

}
