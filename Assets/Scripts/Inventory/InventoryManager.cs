using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    private List<IInventoryItem>[] inventoryItems;

    public InventoryManager()
    {
        inventoryItems = new List<IInventoryItem>[GameManager.NUMBER_OF_PLAYERS]; 
        for (int i = 0; i < GameManager.NUMBER_OF_PLAYERS; i++)
        {
            inventoryItems[i] = new List<IInventoryItem>();
        }
    }

    public void AddToInventory(int player, IInventoryItem item)
    {
        inventoryItems[player].Add(item);
    }

    public IInventoryItem GetItem(int player, int number)
    {
        return inventoryItems[player][number];
    }

    public int GetInventorySize(int player)
    {
        return inventoryItems[player].Count;
    }
}
