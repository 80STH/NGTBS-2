using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public static event EventHandler OnAnyActionAvailableChanged;
    public static event EventHandler OnAnyUnitSpawned;
    public static event EventHandler OnAnyUnitDead;
    //public static event EventHandler OnAnyUnitPushed;


    [SerializeField] private bool isEnemy;

    private GridPosition gridPosition;
    private HealthSystem healthSystem;
    private ShiftSystem shiftSystem;
    private StatusEffectSystem effectSystem;
    protected BaseAction[] baseActionArray;
    private bool movementAvailable = true;
    private bool actionAvailable = true;

    List<StatusEffect> statusEffectList = new List<StatusEffect>();


    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        shiftSystem = GetComponent<ShiftSystem>();
        //mandatory actions
        baseActionArray = GetComponents<BaseAction>();
        //baseActionArray.Append(GetComponent<MoveAction>());
        effectSystem = GetComponent<StatusEffectSystem>();
    }

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);

        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;

        healthSystem.OnDead += HealthSystem_OnDead;
        //shiftSystem.OnPush += ShiftSystem_OnPush;

        OnAnyUnitSpawned?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if (newGridPosition != gridPosition)
        {
            // Unit changed Grid Position
            GridPosition oldGridPosition = gridPosition;
            gridPosition = newGridPosition;

            LevelGrid.Instance.UnitMovedGridPosition(this, oldGridPosition, newGridPosition);
        }
    }

    public virtual T GetAction<T>() where T : BaseAction
    {
        foreach (BaseAction baseAction in baseActionArray)
        {
            if (baseAction is T)
            {
                return (T)baseAction;
            }
        }
        return null;
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }

    public Vector3 GetWorldPosition()
    {
        return transform.position;
    }

    public BaseAction[] GetBaseActionArray()
    {
        return baseActionArray;
    }

    //public void SetGridPosition(GridPosition gridPosition)
    //{
    //    return gridPosition;
    //}

    //public void SetWorldPosition()
    //{
    //    return transform.position;
    //}

    //AI REMINDER!!!
    public bool TrySpendActionAvailabilityToTakeAction(BaseAction baseAction)
    {
        if (baseAction.IsMoveAction() && CanSpendActionAvailablityToTakeAction(baseAction))
        {
            SpendMovementAvailability();
            return true;
        }
        if (CanSpendActionAvailablityToTakeAction(baseAction))
        {
            SpendActionAvailability();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanSpendActionAvailablityToTakeAction(BaseAction baseAction)
    {
        if(baseAction.IsMoveAction() && !movementAvailable)
        {
            return false;
        }
        return actionAvailable;
    }

    private void SpendMovementAvailability()
    {
        movementAvailable = false;

        OnAnyActionAvailableChanged?.Invoke(this, EventArgs.Empty);
    }

    private void SpendActionAvailability()
    {
        movementAvailable = false;
        actionAvailable = false;

        OnAnyActionAvailableChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool IsActionAvailable()
    {
        return actionAvailable;
    }

    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        if ((IsEnemy() && !TurnSystem.Instance.IsPlayerTurn()) ||
            (!IsEnemy() && TurnSystem.Instance.IsPlayerTurn()))
        {
            //it's a turn movement reset
            movementAvailable = true;
            actionAvailable = true;

            OnAnyActionAvailableChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }

    public void Damage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
    }

    public void Shift(Unit unit, string pushDirection)
    {
        gridPosition = shiftSystem.Shift(unit, pushDirection);
    }

    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        LevelGrid.Instance.RemoveUnitAtGridPosition(gridPosition, this);

        Destroy(gameObject);

        OnAnyUnitDead?.Invoke(this, EventArgs.Empty);
    }

    //private void ShiftSystem_OnPush(object sender, EventArgs e)
    //{
    //    OnAnyUnitPushed?.Invoke(this, EventArgs.Empty);
    //}

    public float GetHealthNormalized()
    {
        return healthSystem.GetHealthNormalized();
    }

    public List<StatusEffect> GetStatusEffects()
    {
        return effectSystem.GetStatusEffectList();
    }

}