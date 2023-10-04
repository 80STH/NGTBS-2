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
    private List<Movement> movementsList = new List<Movement>();
    private int index = 0;
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

    private void Start()
    {
        
    }

    public Movement GetLastMovement()
    {
        return movementsList[index];
    }

    public void AddToMovementList(Movement movement)
    {
        movementsList.Add(movement);
        index++;
    }

    public void RemoveFromMovementList()
    {
        movementsList.RemoveAt(index);
        index--;
    }

    public void ClearMovementList()
    {
        movementsList.Clear();
    }
}
