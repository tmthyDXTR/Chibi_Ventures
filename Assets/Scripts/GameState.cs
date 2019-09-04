using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GameState : MonoBehaviour
{
    private PlayerDeck playerDeck;
    private PlayerCardDropZone playerCardDropZone;
    private UnitInfo unit;

    [SerializeField] private int turnCounter = 0;
    public Text turnInfoText;
    public static EventHandler OnTurnChanged;

    [SerializeField] private State state;
    private enum State
    {
        GameStart,
        FirstPlayerTurn,
        FirstEnemyTurn,
        PlayerTurn,
        EnemyTurn,

    }

    void Awake()
    {
        playerDeck = GameObject.Find("PlayerDeck").GetComponent<PlayerDeck>();
        playerCardDropZone = GameObject.Find("PlayerCardDropZone").GetComponent<PlayerCardDropZone>();

        OnTurnChanged += delegate (object sender, EventArgs e)
        {
            UpdateTurnInfoText();
        };


        state = State.GameStart;
    }

    void Update()
    {

        switch (state)
        {
            case State.GameStart:
                if (GameHandler.playerHandSize < GameHandler.playerStartHandSize)
                {
                    Debug.Log("Game Start - Drawing Cards");
                    playerDeck.DrawCard();
                }
                else
                {
                    turnCounter += 1;
                    if (OnTurnChanged != null) OnTurnChanged(null, EventArgs.Empty);

                    state = State.FirstPlayerTurn;
                }          
                break;

            case State.FirstPlayerTurn:

                break;

            case State.FirstEnemyTurn:

                break;

            case State.PlayerTurn:                

                break;

            case State.EnemyTurn:
                break;

        }
    }

    public void EndTurn()
    {
        if (state == State.FirstPlayerTurn)
        {
            state = State.FirstEnemyTurn;
        }
        else if (state == State.FirstEnemyTurn)
        {
            turnCounter += 1;

            GameHandler.AddSupply(2);
            GameHandler.AddMana(1);
            UnitsCanAttack();
            playerDeck.DrawCard();
            
            state = State.PlayerTurn;
        }
        else if (state == State.PlayerTurn)
        {
            state = State.EnemyTurn;
        }
        else if (state == State.EnemyTurn)
        {
            turnCounter += 1;

            GameHandler.AddSupply(2);
            GameHandler.AddMana(1);
            UnitsCanAttack();
            playerDeck.DrawCard();

            state = State.PlayerTurn;
        }

        if (OnTurnChanged != null) OnTurnChanged(null, EventArgs.Empty);

    }

    private void UpdateTurnInfoText()
    {
        turnInfoText.text = state.ToString() + " " + turnCounter;
    }

    private void UnitsCanAttack()
    {
        foreach (GameObject unitCard in playerCardDropZone.droppedPlayerUnits)
        {
            unit = unitCard.GetComponent<UnitInfo>();
            if (unit.canAttack != true)
            {
                unit.canAttack = true;
            }
        }
    }
}
