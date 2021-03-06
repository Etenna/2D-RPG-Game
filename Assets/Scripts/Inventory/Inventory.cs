using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    List<ItemData> itemsList;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        itemsList = new List<ItemData>();
    }

    public void AddItems(ItemData item)
    {
        if (item.IsStackable)
        {
            bool itemAlreadyInInventory = false;

            foreach (ItemData itemInInventory in itemsList)
            {
                if (itemInInventory.ItemName == item.ItemName)
                {
                    itemInInventory.StackAmount += 1;
                    itemAlreadyInInventory = true;
                }
            }

            if (!itemAlreadyInInventory)
            {
                itemsList.Add(item);
            }
        }
        else
        {
            itemsList.Add(item);
        }

    }

    public void RemoveItem(ItemData item)
    {
        if (item.IsStackable && item.StackAmount > 0)
        {
            ItemData inventoryItem = null;

            foreach (ItemData itemInInventory in itemsList)
            {
                if (itemInInventory.ItemName == item.ItemName)
                {
                    itemInInventory.StackAmount --;
                    inventoryItem = itemInInventory;
                }
            }

            if(inventoryItem!=null&&inventoryItem.StackAmount <= 0)
            {
                inventoryItem.StackAmount = 1; // Wird ben?tigt damit beim erneuten Besitzen des Items die Anzahl wieder richtig ausgegeben wird.
                itemsList.Remove(inventoryItem);
            }
        }
        else
        {
            itemsList.Remove(item);
        }
    }

    public int ReturnCountOfItems() => itemsList.Count;
    public List<ItemData> GetItemsList() => itemsList;

}
