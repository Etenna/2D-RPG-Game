using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemDescription : MonoBehaviour
{
    public ItemData itemOnButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press()
    {
        MenuManager.instance.itemName.text = itemOnButton.ItemName;
        MenuManager.instance.itemDescription.text = itemOnButton.ItemDescription;
    }
}
