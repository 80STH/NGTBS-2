using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GridObject
{

    private GridSystemHex<GridObject> gridSystem;
    private GridPosition gridPosition;
    private List<Unit> unitList;
    private List<Building> buildingList;
    private List<TerrainEffect> terrainEffectList;
    private IInteractable interactable;

    public GridObject(GridSystemHex<GridObject> gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();
        buildingList = new List<Building>();
        terrainEffectList = new List<TerrainEffect>();
    }

    public override string ToString()
    {
        string unitString = "";
        foreach (Unit unit in unitList)
        {
            unitString += unit + "\n";
        }

        return gridPosition.ToString() + "\n" + unitString;
    }

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public void AddBuilding(Building building)
    {
        buildingList.Add(building);
    }

    public void RemoveBuilding(Building building)
    {
        buildingList.Remove(building);
    }

    public List<Building> GetBuildingList()
    {
        return buildingList;
    }

    public void AddTerrainEffect(TerrainEffect terrainEffect)
    {
        terrainEffectList.Add(terrainEffect);
    }

    public void RemoveTerrainEffect(TerrainEffect terrainEffect)
    {
        terrainEffectList.Remove(terrainEffect);
    }

    public List<TerrainEffect> GetTerrainEffectList()
    {
        return terrainEffectList;
    }

    public bool HasAnyUnit()
    {
        return unitList.Count > 0;
    }

    public Unit GetUnit()
    {
        if (HasAnyUnit())
        {
            return unitList[0];
        } else
        {
            return null;
        }
    }

    public bool HasAnyBuilding()
    {
        return buildingList.Count > 0;
    }

    public Building GetBuilding()
    {
        if (HasAnyBuilding())
        {
            return buildingList[0];
        }
        else
        {
            return null;
        }
    }

    public bool HasAnyTerrainEffect()
    {
        return terrainEffectList.Count > 0;
    }

    public TerrainEffect GetTerrainEffect()
    {
        if (HasAnyTerrainEffect())
        {
            return terrainEffectList[0];
        }
        else
        {
            return null;
        }
    }

    public IInteractable GetInteractable()
    {
        return interactable;
    }

    public void SetInteractable(IInteractable interactable)
    {
        this.interactable = interactable;
    }

    public void ClearInteractable()
    {
        this.interactable = null;
    }

}