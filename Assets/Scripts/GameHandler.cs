using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public static class GameHandler
{
    public static int playerHealth;
    public static int playerSupply;
    public static int playerMana;
    public static EventHandler OnPlayerHealthChanged;
    public static EventHandler OnPlayerSupplyChanged;
    public static EventHandler OnPlayerManaChanged;

    public static int playerFreeUnitSlots;
    public static EventHandler OnPlayerFreeUnitSlotsChanged;

    public static int playerHandSize;
    public static int playerMaxHandSize;
    public static int playerStartHandSize;


    public static void PlayerGrabUnit()
    {
        playerFreeUnitSlots += 1;
        if (OnPlayerFreeUnitSlotsChanged != null) OnPlayerFreeUnitSlotsChanged(null, EventArgs.Empty);
    }

    public static void PlayerDropUnit()
    {
        playerFreeUnitSlots -= 1;
        if (OnPlayerFreeUnitSlotsChanged != null) OnPlayerFreeUnitSlotsChanged(null, EventArgs.Empty);
    }

    public static int GetPlayerFreeUnitSlots()
    {
        return playerFreeUnitSlots;
    }
    
    public static bool CheckPlayerUnitSlots()
    {
        if (playerFreeUnitSlots > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static void RemoveHealth(int amount)
    {
        Debug.Log("Removed " + amount + " Health");
        playerHealth -= amount;
        if (OnPlayerHealthChanged != null) OnPlayerHealthChanged(null, EventArgs.Empty);
    }

    public static void AddHealth(int amount)
    {
        Debug.Log("Added " + amount + " Health");
        playerHealth += amount;
        if (OnPlayerHealthChanged != null) OnPlayerHealthChanged(null, EventArgs.Empty);
    }


    public static void RemoveSupply(int amount)
    {
        Debug.Log("Removed " + amount + " Supply");
        playerSupply -= amount;
        if (OnPlayerSupplyChanged != null) OnPlayerSupplyChanged(null, EventArgs.Empty);
    }

    public static void AddSupply(int amount)
    {
        Debug.Log("Added " + amount + " Supply");
        playerSupply += amount;
        if (OnPlayerSupplyChanged != null) OnPlayerSupplyChanged(null, EventArgs.Empty);
    }


    public static void RemoveMana(int amount)
    {
        Debug.Log("Removed " + amount + " Mana");
        playerMana -= amount;
        if (OnPlayerManaChanged != null) OnPlayerManaChanged(null, EventArgs.Empty);
    }

    public static void AddMana(int amount)
    {
        Debug.Log("Added " + amount + " Mana");
        playerMana += amount;
        if (OnPlayerManaChanged != null) OnPlayerManaChanged(null, EventArgs.Empty);
    }
}
