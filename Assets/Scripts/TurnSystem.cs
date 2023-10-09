using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnSystem : MonoBehaviour
{

    public static TurnSystem Instance { get; private set; }


    public event EventHandler OnTurnChanged;


    private int turnNumber = 3;
    private int playerTurnNumber = 1;
    private bool isPlayerTurn = true;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one TurnSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    public void NextTurn()
    {
        turnNumber++;
        if (isPlayerTurn)
        {
            playerTurnNumber--;
        }
        if(playerTurnNumber == 0)
        {
            Win();
            return;
        }
        isPlayerTurn = !isPlayerTurn;

        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetTurnNumber()
    {
        return playerTurnNumber;
    }

    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    private void Win()
    {
        SceneManager.LoadScene("WinScreen");
    }

}
