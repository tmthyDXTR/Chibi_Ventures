using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerStats : MonoBehaviour
{
    public GameRules gameRules;

    public Text playerHealthText;
    public Text playerSupplyText;
    public Text playerManaText;

    void Awake()
    {
        gameRules = GameObject.Find("GameRules").GetComponent<GameRules>();

        playerHealthText.text = GameHandler.playerHealth.ToString();
        playerSupplyText.text = GameHandler.playerSupply.ToString();
        playerManaText.text = GameHandler.playerMana.ToString();

        GameHandler.OnPlayerHealthChanged += delegate (object sender, EventArgs e)
        {
            UpdatePlayerHealthText();
        };
        GameHandler.OnPlayerSupplyChanged += delegate (object sender, EventArgs e)
        {
            UpdatePlayerSupplyText();
        };
        GameHandler.OnPlayerManaChanged += delegate (object sender, EventArgs e)
        {
            UpdatePlayerManaText();
        };
    }

    private void UpdatePlayerHealthText()
    {
        playerHealthText.text = GameHandler.playerHealth.ToString();
    }
    private void UpdatePlayerSupplyText()
    {
        playerSupplyText.text = GameHandler.playerSupply.ToString();
    }
    private void UpdatePlayerManaText()
    {
        playerManaText.text = GameHandler.playerMana.ToString();
    }

    void Update()
    {
        
    }
}
