using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoManager : MonoBehaviour
{
    public event EventHandler OnUndoMovement;
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

    public void UndoMovement() //return+remove //rewrite!!!
    {
        Movement movement = movementStack.Pop();
        Unit unit = movement.unit;
        GridPosition gridPosition = movement.gridPosition;
        unit.SetGridPosition(gridPosition);
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
