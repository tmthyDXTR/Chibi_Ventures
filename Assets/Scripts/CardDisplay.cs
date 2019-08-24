using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDisplay : MonoBehaviour
{
    public Card_Unit card_unit;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public Text costText;
    public Text physicalAttackText;
    public Text magicalAttackText;
    public Text armorText;
    public Text healthText;

    void Start()
    {
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
}