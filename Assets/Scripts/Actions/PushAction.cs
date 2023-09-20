using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAction : BaseAction
{
    public class OnShootEventArgs : EventArgs
    {
        public Unit targetUnit;
        public Unit pushedUnit;
    }
    private int maxPushDistance = 1;
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

                IInteractable interactable = LevelGrid.Instance.GetInteractableAtGridPosition(testGridPosition);

                if (interactable == null)
                {
                    // No interactable on this GridPosition
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        //targetUnit = LevelGrid.Instance.GetUnitAtGridPosition(gridPosition);

        //state = State.Aiming;
        //float aimingStateTime = 1f;
        //stateTimer = aimingStateTime;

        //canShootBullet = true;

        ActionStart(onActionComplete);
    }
    //public Unit GetTargetUnit()
    //{
    //    return targetUnit;
    //}
}
