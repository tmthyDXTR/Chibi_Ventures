using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private PlayerDeck playerDeck;
    private int turnCounter = 0;

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
                    state = State.FirstPlayerTurn;
                }          
                break;

            case State.FirstPlayerTurn:
                Debug.Log("Player Turn " + turnCounter);

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
            GameHandler.AddSupply(2);
            GameHandler.AddMana(1);
            state = State.PlayerTurn;
        }
        else if (state == State.PlayerTurn)
        {
            state = State.EnemyTurn;
        }
        else if (state == State.EnemyTurn)
        {
            GameHandler.AddSupply(2);
            GameHandler.AddMana(1);
            state = State.PlayerTurn;
        }
    }
}
