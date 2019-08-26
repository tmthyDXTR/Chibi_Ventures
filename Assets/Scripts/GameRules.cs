using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    //PlayerConfig

    public int playerHealth;
    public int playerSupply;
    public int playerMana;
    public int playerDeckSize;
    public int playerStartHandSize;
    public int playerMaxHandSize;
    public int playerUnitSlots;



    //EnemyConfig
    public int enemyHealth;
    public int enemySupply;
    public int enemyMana;
    public int enemyDeckSize;


    void Awake()
    {
        GameHandler.playerHealth = playerHealth;
        GameHandler.playerSupply = playerSupply;
        GameHandler.playerMana = playerMana;
        GameHandler.playerFreeUnitSlots = playerUnitSlots;
        GameHandler.playerHandSize = 0;
        GameHandler.playerStartHandSize = playerStartHandSize;
        GameHandler.playerMaxHandSize = playerMaxHandSize;

    }
}
