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
                    state = State.PlayerTurn;
                }          
                break;

            case State.PlayerTurn:
                //Debug.Log("Player Turn " + turnCounter);

                break;

            case State.EnemyTurn:

                break;

        }
    }

    public void EndTurn()
    {
        state = State.EnemyTurn;
    }
}
