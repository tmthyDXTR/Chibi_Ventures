using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDisplay : MonoBehaviour
{
    public Card_Unit card_unit;
    public Card_Spell card_spell;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public Text costText;
    public Text physicalAttackText;
    public Text magicalAttackText;
    public Text armorText;
    public Text healthText;

    public int cost;
    public int physicalAttack;
    public int magicalAttack;
    public int armor;
    public int health;

    void Start()
    {

        if (card_unit != null)
        {
            cost = card_unit.cost;

            nameText.text = card_unit.name;
            descriptionText.text = card_unit.description;

            artworkImage.sprite = card_unit.unitArtwork;

            costText.text = card_unit.cost.ToString();

            if (card_unit.physicalAttack != 0)
            {
                physicalAttackText.text = card_unit.physicalAttack.ToString();
            }
            else
            {
                physicalAttackText.text = "";
            }

            if (card_unit.magicalAttack != 0)
            {
                magicalAttackText.text = card_unit.magicalAttack.ToString();
            }
            else
            {
                magicalAttackText.text = "";
            }

            armorText.text = card_unit.armor.ToString();
            healthText.text = card_unit.health.ToString();
        }
        else if (card_spell != null)
        {
            cost = card_spell.cost;

            nameText.text = card_spell.name;
            descriptionText.text = card_spell.description;

            artworkImage.sprite = card_spell.spellArtwork;

            costText.text = card_spell.cost.ToString();          
        }
    }
}