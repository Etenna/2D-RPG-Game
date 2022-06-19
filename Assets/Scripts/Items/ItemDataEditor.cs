using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemData))]
public class ItemDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var itemdata = target as ItemData;

        itemdata.type=(ItemData.ItemType)EditorGUILayout.EnumPopup("ItemType",itemdata.type);
        itemdata.ItemID = EditorGUILayout.TextField("ItemID", itemdata.ItemID);
        itemdata.ItemName=EditorGUILayout.TextField("ItemName",itemdata.ItemName);
        itemdata.ItemDescription=EditorGUILayout.TextField("ItemDescription",itemdata.ItemDescription);
        itemdata.ValueInCoins=EditorGUILayout.IntField("ValueInCoins",itemdata.ValueInCoins);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("ItemImage");
        itemdata.ItemImage = (Sprite)EditorGUILayout.ObjectField(itemdata.ItemImage, typeof(Sprite),allowSceneObjects:true);
        EditorGUILayout.EndHorizontal();

        if (itemdata.type == ItemData.ItemType.Armor)
        {
            itemdata.armorType = (ItemData.ArmorType)EditorGUILayout.EnumPopup("ArmorType", itemdata.armorType);
            itemdata.ArmorDefence=EditorGUILayout.IntField("ArmorDefence",itemdata.ArmorDefence);
        }
        else if(itemdata.type == ItemData.ItemType.Weapon)
        {
            itemdata.WeaponDamage=EditorGUILayout.IntField("WeaponDamage",itemdata.WeaponDamage);
        }
        else if (itemdata.type == ItemData.ItemType.Potion)
        {
            itemdata.typeEffect = (ItemData.TypeEffect)EditorGUILayout.EnumPopup("TypeEffect", itemdata.typeEffect);
            itemdata.AmountOfEffect = EditorGUILayout.IntField("AmountOfEffect", itemdata.AmountOfEffect);
        }

        if(GUILayout.Button("Save Asset"))
        {
            EditorUtility.SetDirty(itemdata);
        }
    }
}
