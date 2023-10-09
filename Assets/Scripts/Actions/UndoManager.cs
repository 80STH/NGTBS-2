using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoManager : MonoBehaviour
{ 
    //public event EventHandler OnActionOrEndTurn;
    public struct Movement
    {
        public Unit unit;
        public GridPosition gridPosition;

        public Movement(Unit unit, GridPosition gridPosition)
        {
            this.unit = unit;
            this.gridPosition = gridPosition;
        }
    }
    public static UndoManager Instance { get; private set; }
    private Stack<Movement> movementStack = new Stack<Movement>();
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one UndoManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        //UndoManager_OnActionOrEndTurn();
    }

    public void UndoMovement() //return+remove //rewrite!!!
    {
        if (movementStack.Count > 0)
        {
            Movement movement = movementStack.Pop();
            Unit unit = movement.unit;
            GridPosition undoGridPosition = movement.gridPosition;
            GridPosition oldGridPosition = unit.GetGridPosition();
            LevelGrid.Instance.UnitMovedGridPosition(unit, oldGridPosition, undoGridPosition);
            unit.transform.position = LevelGrid.Instance.GetWorldPosition(undoGridPosition);
        }
    }

    public void AddToMovementStack(Unit unit, GridPosition gridPosition)
    {
        Movement movement = new Movement(unit, gridPosition);
        movementStack.Push(movement);
    }

    
    //clears after every non-move action or end of player's turn
    public void ClearMovementStack()
    {
        movementStack.Clear();
    }
}
