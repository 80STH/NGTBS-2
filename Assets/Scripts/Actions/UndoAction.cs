using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoAction : BaseAction
{
    //here i have to add infinite list of previous movements 
    public override string GetActionName()
    {
        return "Undo move";
    }

    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        //because enemies aren't able to use this
        //maybe rewrite later
        throw new NotImplementedException();
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        //it's a specific action
        throw new NotImplementedException();
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        throw new NotImplementedException();
    }

    //only applies to movement!!!

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
