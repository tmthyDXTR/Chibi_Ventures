using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public GameRules gameRules;

    public Text playerHealthText;
    public Text playerSupplyText;
    public Text playerManaText;

    void Start()
    {
        gameRules = GameObject.Find("GameRules").GetComponent<GameRules>();

        playerHealthText.text = gameRules.playerHealth.ToString();
        playerSupplyText.text = gameRules.playerSupply.ToString();
        playerManaText.text = gameRules.playerMana.ToString();

    }

    void Update()
    {
        
    }
}
