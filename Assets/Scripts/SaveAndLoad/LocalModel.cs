using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalModel : MonoBehaviour
{
    public int[] GroundData =
        {25, 25, 25, 34, 34, 34, 34, 34, 34, 25, 25,
         25, 25, 34, 23, 23, 23, 23, 23, 34, 25, 25,
         25, 25, 34, 23, 23, 23, 23, 23, 23, 34, 25,
         25, 34, 23, 23, 23, 23, 23, 23, 23, 34, 25,
         25, 34, 23, 23, 23, 23, 23, 23, 23, 23, 34,
         34, 23, 23, 23, 23, 23, 23, 23, 23, 23, 34,
         25, 34, 23, 23, 23, 23, 23, 23, 23, 23, 34,
         25, 34, 23, 23, 23, 23, 23, 23, 23, 34, 25,
         25, 25, 34, 23, 23, 23, 23, 23, 23, 34, 25,
         25, 25, 34, 23, 23, 23, 23, 23, 34, 25, 25,
         25, 25, 25, 34, 34, 34, 34, 34, 34, 25, 25};
    public List<DataUnit> Units = new List<DataUnit>
    {
        new DataUnit()
        {
            gridPosition = new GridPosition(0, 0),
            health = 2,
            isEnemy = false,
            isMoveAvailable = true,
            isWeaponAvailable = true,
            typeOfUnit = "Grenade",
            statusEffectsList = new List<string>{
                "Fire"
            }

        }
    };
    public List<DataBuilding> Buildings = new List<DataBuilding>
    {
        new DataBuilding()
        {
            gridPosition = new GridPosition(0, 0),
            health = 2,
            typeOfBuilding = "GridBuilding",
            statusEffectsList = new List<string>{
                "Fire"
            }
        }
    };
    public List<DataTerrainEffect> TerrainEffects = new List<DataTerrainEffect>
    {
        new DataTerrainEffect()
        {
            gridPosition = new GridPosition(0, 0),
            terrainEffectsList = new List<string>{
                "Fire"
            }
        }
    };
    public bool IsUndoAvailable = true; //i don't want to save undo
    public int Hull = 7; //subject to change
}
