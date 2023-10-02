using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HullSystemUI : MonoBehaviour
{

    //[SerializeField] private Button endTurnBtn;
    [SerializeField] private TextMeshProUGUI hullText;
    [SerializeField] private HullSystem hullSystem;
    //[SerializeField] private GameObject enemyTurnVisualGameObject;

    private void Start()
    {
        //endTurnBtn.onClick.AddListener(() =>
        //{
        //    TurnSystem.Instance.NextTurn();
        //});

        //TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;
        hullSystem.OnHullChanged += HullSystem_OnHullChanged;

        UpdateHullText();
        //UpdateEnemyTurnVisual();
        //UpdateEndTurnButtonVisibility();
    }

    private void HullSystem_OnHullChanged(object sender, EventArgs e)
    {
        UpdateHullText();
    }

    private void UpdateHullText()
    {
        hullText.text = "HULL: " + HullSystem.Instance.GetHull();
    }

    //private void UpdateEnemyTurnVisual()
    //{
    //    enemyTurnVisualGameObject.SetActive(!TurnSystem.Instance.IsPlayerTurn());
    //}

    //private void UpdateEndTurnButtonVisibility()
    //{
    //    endTurnBtn.gameObject.SetActive(TurnSystem.Instance.IsPlayerTurn());
    //}


}
