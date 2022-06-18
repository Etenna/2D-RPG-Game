using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item Data", menuName ="Item Data")]
public class ItemData : ScriptableObject
{
    public enum ItemType { Item,Weapon,Armor,QuestItem,Potion}
    [SerializeField] ItemType type;
    [SerializeField] string itemID;
    
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [SerializeField] int valueInCoins;
    [SerializeField] Sprite itemImage;

    [SerializeField] int weaponDamage;
    [SerializeField] int armorDefence;

    public enum TypeEffect { HP,Mana}
    TypeEffect typeEffect;
    [SerializeField] int amountOfEffect;


    public ItemType Type { get { return type; } }
    public string ItemID { get { return itemID; } }
    public string ItemName { get { return itemName; } }
    public string ItemDescription { get { return itemDescription; } }
    public int ValueInCoins { get { return valueInCoins; } }
    public Sprite ItemImage { get { return itemImage; } }
    public int WeaponDamage { get { return weaponDamage; } }
    public int ArmorDefence { get { return armorDefence; } }
    public TypeEffect Effect { get { return typeEffect; } }
    public int AmountOfEffect { get { return amountOfEffect; } }
}
