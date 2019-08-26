using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New_Spell_Card", menuName = "Cards/Spells")]
public class Card_Spell : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite spellArtwork;

    public int cost;


}
