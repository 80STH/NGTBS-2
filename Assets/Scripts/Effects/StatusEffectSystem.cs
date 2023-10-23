using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectSystem : MonoBehaviour
{
    //uncomment if i want to add proper visual
    //public event EventHandler OnDead;
    //public event EventHandler OnDamaged;

    private List<StatusEffect> statusEffectList;

    private void Awake()
    {
        statusEffectList = new List<StatusEffect>();
    }

    public void ApplyStatusEffect(StatusEffect statusEffect)
    {
        statusEffectList.Add(statusEffect);
    }

    private void ClearStatusEffect(StatusEffect statusEffect)
    {
        if (statusEffectList.Count > 0)
        {
            statusEffectList.Remove(statusEffect);
        }
    }

    public List<StatusEffect> GetStatusEffectList()
    {
        return statusEffectList;
    }

    public void ApplyStatusEffect(string typeOfStatusEffect)
    {
        //temporary!!!
        typeOfStatusEffect = "Fire";

    }

}
