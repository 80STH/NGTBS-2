using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    //public static event EventHandler OnAnyDoorOpened;
    //public event EventHandler OnDoorOpened;

    private GridPosition gridPosition;
    //private Animator animator;
    //private Action onInteractionComplete;
    //private bool isActive;
    //private float timer;

    protected bool IsWalkable;
    protected bool IsDeadly;
    protected bool IsEdge;
}