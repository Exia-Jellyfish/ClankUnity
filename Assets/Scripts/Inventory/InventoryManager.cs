using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    private List<IInventoryItem> inventoryItems;
    public List<IInventoryItem> InventoryItems { get => inventoryItems; private set => inventoryItems = value; }

    public InventoryManager()
    {
        InventoryItems = new List<IInventoryItem>();
    }

    public void AddToInventory(IInventoryItem item)
    {
        inventoryItems.Add(item);
    }
}
