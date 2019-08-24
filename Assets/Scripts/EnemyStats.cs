using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public GameRules gameRules;

    public Text enemyHealthText;
    public Text enemySupplyText;
    public Text enemyManaText;

    void Start()
    {
        gameRules = GameObject.Find("GameRules").GetComponent<GameRules>();

        enemyHealthText.text = gameRules.enemyHealth.ToString();
        enemySupplyText.text = gameRules.enemySupply.ToString();
        enemyManaText.text = gameRules.enemyMana.ToString();

    }

    void Update()
    {
        
    }
}
