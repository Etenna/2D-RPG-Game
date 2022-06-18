using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public enum ItemType { Item,Weapon,Armor}
    public ItemType itemType;

    public string itemName, itemDescription;
    public int valueInCoins;
    public Sprite itemImage;

    public int weaponDamage;
    public int weaponDexterity;
    public int armorDefence;
    public enum TypeOfEffect { HP,Mana}
    public TypeOfEffect typeOfEffect;
    public int amountOfEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
