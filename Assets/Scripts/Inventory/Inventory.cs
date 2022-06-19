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
        Instance = this;
    }
    void Start()
    {
        itemsList = new List<ItemData>();

        Debug.Log("New Inventory List has created!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItems(ItemData item)
    {
        itemsList.Add(item);
    }
    public int ReturnCountOfItems()
    {
        return itemsList.Count;
    }
}
