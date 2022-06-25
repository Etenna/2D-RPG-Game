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

    // Update is called once per frame
    void Update()
    {
        
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
    public int ReturnCountOfItems()
    {
        return itemsList.Count;
    }

    public List<ItemData> GetItemsList()
    {
        return itemsList;
    }
}
