using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    List<ItemsManager> itemsList;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        itemsList = new List<ItemsManager>();

        Debug.Log("New Inventory List has created!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItems(ItemsManager item)
    {
        itemsList.Add(item);
    }
}
