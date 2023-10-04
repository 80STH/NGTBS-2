using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoMovementsManager : MonoBehaviour
{
    public struct Movement
    {
        Unit unit;
        Vector3 position;
    }
    public static UndoMovementsManager Instance { get; private set; }
    private Stack<Movement> movementStack = new Stack<Movement>();
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one UndoMovementsManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public Movement GetLastMovement() //return+remove
    {
        return movementStack.Pop();
    }

    public void AddToMovementStack(Movement movement)
    {
        movementStack.Push(movement);
    }

    public void ClearMovementStack()
    {
        movementStack.Clear();
    }
}
