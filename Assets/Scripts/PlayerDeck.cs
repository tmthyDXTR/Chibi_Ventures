using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

    public List<GameObject> deckList = new List<GameObject>();

    public Transform playerHand;

    void Awake()
    {
        playerHand = GameObject.Find("PlayerHand").transform;

        AddCardToDeckList("Unit_Warrior");
        AddCardToDeckList("Unit_Warrior");
        AddCardToDeckList("Unit_Warrior");
        AddCardToDeckList("Unit_Warrior");
        AddCardToDeckList("Unit_Warrior");
        AddCardToDeckList("Unit_Warrior");
        AddCardToDeckList("Unit_Mage");
        AddCardToDeckList("Unit_Mage");
        AddCardToDeckList("Unit_Mage");
        AddCardToDeckList("Unit_Mage");
        //AddCardToDeckList("Spell_Fireball");
        //AddCardToDeckList("Spell_Fireball");
        //AddCardToDeckList("Spell_Fireball");
        //AddCardToDeckList("Spell_Fireball");
        //AddCardToDeckList("Spell_IceBlast");
        //AddCardToDeckList("Spell_IceBlast");
        //AddCardToDeckList("Spell_IceBlast");
        //AddCardToDeckList("Spell_Tornado");
        //AddCardToDeckList("Spell_Tornado");
        //AddCardToDeckList("Spell_Tornado");

        ShuffleDeck();
    }

    void Update()
    {
        
    }

    public void DrawCard()
    {
        if (deckList.Count > 0 && GameHandler.playerHandSize < GameHandler.playerMaxHandSize)
        {
            deckList[0].transform.SetParent(playerHand);
            deckList[0].GetComponent<Draggable>().originalParent = playerHand;
            deckList.RemoveAt(0);
            GameHandler.playerHandSize += 1;
            playerHand.GetComponent<PlayerHand>().playerHandList.Add(deckList[0]);
        }
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < deckList.Count; i++)
        {
            GameObject temp = deckList[i];
            int randomIndex = Random.Range(i, deckList.Count);
            deckList[i] = deckList[randomIndex];
            deckList[randomIndex] = temp;
        }
    }

    public void AddCardToDeckList(string cardName)
    {
        GameObject cardPrefab = Resources.Load(cardName) as GameObject;
        GameObject card = Instantiate(cardPrefab, this.transform.position, Quaternion.identity, this.transform) as GameObject;
        card.transform.localScale = new Vector3(card.transform.localScale.x *0.33f, card.transform.localScale.y *0.33f, 0);
        deckList.Add(card);
    }
}
