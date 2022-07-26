using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager Instance; 
    [SerializeField] ItemData itemData;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemData.ItemImage;
    }

    public void UseItem(ItemData item, int characterToUseOn)
    {

        PlayerStats selectedCharacter = GameManager.instance.GetPlayerStats()[characterToUseOn];
        if (item.type == ItemData.ItemType.Potion)
        {
            if (item.typeEffect == ItemData.TypeEffect.HP)
            {
                selectedCharacter.AddHP(item.AmountOfEffect);
            }
            else if (item.typeEffect == ItemData.TypeEffect.Mana)
            {
                selectedCharacter.AddMana(item.AmountOfEffect);
            }
        }
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
