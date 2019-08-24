using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New_Unit_Card", menuName = "Cards/Units")]
public class Card_Unit : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite unitArtwork;

    public int cost;
    public int physicalAttack;
    public int magicalAttack;
    public int armor;
    public int health;


}
