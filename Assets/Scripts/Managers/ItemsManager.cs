using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] ItemData itemData;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemData.ItemImage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"Player hits the trigger on Gameobject: {itemData.ItemName}");
            Inventory.Instance.AddItems(itemData);
            Debug.Log($"Item: {itemData} hinzugefügt.");
            DestroyAfterPickUp();
            Debug.Log(Inventory.Instance.ReturnCountOfItems());
        }
    }

    private void DestroyAfterPickUp() => Destroy(gameObject);
}
