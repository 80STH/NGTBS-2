using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushInteraction : MonoBehaviour
{
    public static PushInteraction Instance { get; private set; }

    private Unit targetUnit;
    private Unit collidedUnit;
    private Building collidedBuilding;
    private string direction;
    public GridPosition newGridPosition;
    private HealthSystem healthSystem;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one LevelGrid! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Push(Unit targetUnit, string direction)
    {
        Debug.Log(direction);
        GridPosition gridPosition = GridPosition.TileMove(targetUnit.GetGridPosition(), direction);
        
        CheckCollision(targetUnit, gridPosition);

    }

    public void CheckCollision(Unit targetUnit, GridPosition gridPosition)
    {
        if (LevelGrid.Instance.HasAnyUnitOnGridPosition(gridPosition))
        {
            collidedUnit = LevelGrid.Instance.GetUnitAtGridPosition(gridPosition);
            UnitCollision(targetUnit);
            return;
        }
        if (LevelGrid.Instance.HasAnyBuildingOnGridPosition(gridPosition))
        {
            collidedBuilding = LevelGrid.Instance.GetBuildingAtGridPosition(gridPosition);
            BuildingCollision(targetUnit);
            return;
        }
        //if (LevelGrid.Instance.HasAnyEdgeOnGridPosition(gridPosition))
        //{
        //    EdgeOfMapCollision();
        //}
        else
        {
            Shift(targetUnit, gridPosition);
            return;
        }
    }

    public void EdgeOfMapCollision()
    {

    }

    public void UnitCollision(Unit targetUnit)
    {
        //for testing
        if(targetUnit == collidedUnit)
        {
            Debug.LogError("Collision with the same unit!");
        }
        targetUnit.Damage(1);
        collidedUnit.Damage(1);
    }

    public void BuildingCollision(Unit targetUnit)
    {
        targetUnit.Damage(1);
        collidedBuilding.Damage(1);
    }

    public void Shift(Unit targetUnit, GridPosition gridPosition)
    {
        targetUnit.transform.position = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }
}
