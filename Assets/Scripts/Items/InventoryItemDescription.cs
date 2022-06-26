using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemDescription : MonoBehaviour,ISelectHandler
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
        MenuManager.instance.activeItem = itemOnButton;
    }

    public void OnSelect(BaseEventData eventData)
    {
        MenuManager.instance.itemName.text = itemOnButton.ItemName;
        MenuManager.instance.itemDescription.text = itemOnButton.ItemDescription;
    }
}
