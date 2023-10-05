using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UndoUI : MonoBehaviour
{
    [SerializeField] private Button UndoButton;

    private void Start()
    {
        UndoButton.onClick.AddListener(() =>
        {
            UndoManager.Instance.UndoMovement();
        });

        //UndoManager.Instance.OnUndoMovement += UndoManager_OnUndoMovement;

        //UpdateTurnText();
        //UpdateEnemyTurnVisual();
        //UpdateEndTurnButtonVisibility();
    }

    //private void UndoManager_OnUndoMovement(object sender, EventArgs e)
    //{
    //    //UpdateTurnText();
    //    //UpdateEnemyTurnVisual();
    //    //UpdateEndTurnButtonVisibility();
    //}
}
