using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAction : BaseAction
{
    public static event EventHandler<OnShootEventArgs> OnAnyShoot;

    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Unit targetUnit;
        public Unit pushedUnit;
    }
    private List<Vector3> positionList;

    private int maxPushDistance = 1;
    private Unit targetUnit;

    private void Update()
    {
        if (!isActive)
        {
            return;
        }
    }
    public override string GetActionName()
    {
        return "Push";
    }

    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        return new EnemyAIAction
        {
            gridPosition = gridPosition,
            actionValue = 0
        };
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = unit.GetGridPosition();

        for (int x = -maxPushDistance; x <= maxPushDistance; x++)
        {
            for (int z = -maxPushDistance; z <= maxPushDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    continue;
                }

                if (!LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                {
                    // Grid Position is empty, no Unit
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        targetUnit = LevelGrid.Instance.GetUnitAtGridPosition(gridPosition);
        PushInteraction.Instance.Push(targetUnit, "Left");
        ActionStart(onActionComplete);
    }
}
