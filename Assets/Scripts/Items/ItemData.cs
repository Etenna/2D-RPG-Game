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

    [SerializeField] bool isStackable;
    [SerializeField] bool isEquipped;
    [SerializeField] int stackAmount;
    [SerializeField] int maxStackAmount;



    public void UseItem(int characterToUseOn)
    {
        PlayerStats selectedCharacter = GameManager.instance.GetPlayerStats()[characterToUseOn];

        if (type == ItemData.ItemType.Potion)
        {
            if (typeEffect == ItemData.TypeEffect.HP)
            {
                selectedCharacter.AddHP(AmountOfEffect);
            }
            else if (typeEffect == ItemData.TypeEffect.Mana)
            {
                selectedCharacter.AddMana(AmountOfEffect);
            }
        }
        else if(type == ItemData.ItemType.Armor)
        {
            if (isEquipped)
            {
                selectedCharacter.UnEquipArmor(ArmorDefence);
            }
            else
            {
                selectedCharacter.EquipArmor(ArmorDefence,ItemName);
            }
        }
        else if (type == ItemData.ItemType.Weapon)
        {
            if (isEquipped)
            {
                selectedCharacter.UnEquipWeapon(WeaponDamage);
            }
            else
            {
                selectedCharacter.EquipWeapon(WeaponDamage,ItemName);
            }
        }
    }

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
    public bool IsStackable { get { return isStackable; } set {isStackable = value; } }
    public bool IsEquipped { get { return isEquipped; } set { isEquipped = value; } }
    public int StackAmount { get { return stackAmount; } set { stackAmount = value; } }
    public int MaxStackAmount { get { return maxStackAmount; } }
}
