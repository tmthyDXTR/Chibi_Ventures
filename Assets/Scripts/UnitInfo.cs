using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInfo : MonoBehaviour
{
    private Card_Unit card_unit;

    public int cost;
    public int physicalAttack;
    public int magicalAttack;
    public int armor;
    public int health;

    public bool canAttack = false;


    void Awake()
    {
        card_unit = GetComponent<CardDisplay>().card_unit;

        cost = card_unit.cost;
        physicalAttack = card_unit.physicalAttack;
        magicalAttack = card_unit.magicalAttack;
        armor = card_unit.armor;
        health = card_unit.health;
    }

    void Update()
    {
        
    }
}
