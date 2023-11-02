using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataUnit : MonoBehaviour
{
    public GridPosition gridPosition;
    public int health;
    public bool isEnemy;
    public bool isMoveAvailable;
    public bool isWeaponAvailable;
    public string typeOfUnit; //this will be probably a link to global state
    public List<string> statusEffectsList;
}
