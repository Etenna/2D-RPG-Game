using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="New Item Data", menuName ="Item Data")]
public class ItemData : ScriptableObject
{
    public enum ItemType { Item,Weapon,Armor,QuestItem,Potion}
    public ItemType type;
    public enum ArmorType { Head,Chest,Shield}
    public ArmorType armorType;

    [SerializeField] string itemID="0";
    
    [SerializeField] string itemName="default";
    [TextArea]
    [SerializeField] string itemDescription="default";
    [SerializeField] int valueInCoins=0;
    [SerializeField] Sprite itemImage=null;

    [SerializeField] int weaponDamage=0;
    [SerializeField] int armorDefence=0;

    public enum TypeEffect { HP,Mana}
    public TypeEffect typeEffect;
    [SerializeField] int amountOfEffect = 0;



    public ItemType Type { get { return type; } }
    public string ItemID { get { return itemID; } set { itemID = value; } }
    public string ItemName { get { return itemName; }set { itemName = value; } }
    public string ItemDescription { get { return itemDescription; } set { itemDescription = value; } }
    public int ValueInCoins { get { return valueInCoins; } set { valueInCoins = value; } }
    public Sprite ItemImage { get { return itemImage; } set { itemImage = value; } }
    public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }
    public int ArmorDefence { get { return armorDefence; } set { armorDefence = value; } }
    public TypeEffect Effect { get { return typeEffect; } }
    public int AmountOfEffect { get { return amountOfEffect; } set { amountOfEffect = value; } }
}
