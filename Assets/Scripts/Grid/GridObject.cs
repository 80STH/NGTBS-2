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
    private IInteractable interactable;

    public GridObject(GridSystemHex<GridObject> gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();
        buildingList = new List<Building>();
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