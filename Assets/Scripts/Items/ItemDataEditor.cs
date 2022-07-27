using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(ItemData))]
[System.Serializable]
public  class ItemDataEditor : Editor
{

    SerializedProperty _itemType;
    SerializedProperty _armorType;
    SerializedProperty _typeEffect;
    SerializedProperty _itemID;
    SerializedProperty _itemName;
    SerializedProperty _itemDescription;
    SerializedProperty _itemImage;
    SerializedProperty _valueInCoins;
    SerializedProperty _armorDefence;
    SerializedProperty _weaponDamage;
    SerializedProperty _amountOfEffect;
    SerializedProperty _isStackable;
    SerializedProperty _isEquipped;
    SerializedProperty _stackAmount;
    SerializedProperty _maxStackAmount;




    private void OnEnable()
    {
        _itemType = serializedObject.FindProperty("type");
        _armorType = serializedObject.FindProperty("armorType");
        _typeEffect = serializedObject.FindProperty("typeEffect");
        _itemID = serializedObject.FindProperty("itemID");
        _itemName = serializedObject.FindProperty("itemName");
        _itemDescription = serializedObject.FindProperty("itemDescription");
        _valueInCoins = serializedObject.FindProperty("valueInCoins");
        _itemImage = serializedObject.FindProperty("itemImage");
        _weaponDamage = serializedObject.FindProperty("weaponDamage");
        _armorDefence = serializedObject.FindProperty("armorDefence");
        _amountOfEffect = serializedObject.FindProperty("amountOfEffect");
        _isStackable = serializedObject.FindProperty("isStackable");
        _isEquipped = serializedObject.FindProperty("isEquipped");
        _stackAmount = serializedObject.FindProperty("stackAmount");
        _maxStackAmount = serializedObject.FindProperty("maxStackAmount");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();
        EditorGUILayout.PropertyField(_itemType, new GUIContent("Item Type"));

        EditorGUILayout.PropertyField(_itemID, new GUIContent("Item ID"));
        EditorGUILayout.PropertyField(_itemName, new GUIContent("Item Name"));
        EditorGUILayout.PropertyField(_itemDescription, new GUIContent("Item Description"));
        EditorGUILayout.PropertyField(_itemImage, new GUIContent("Item Image"));
        EditorGUILayout.PropertyField(_valueInCoins, new GUIContent("Value In Coins"));

        if (_itemType.intValue == 1)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_weaponDamage, new GUIContent("Weapon Damage"));
            EditorGUILayout.PropertyField(_isEquipped, new GUIContent("Equipped"));
            EditorGUI.indentLevel--;
        }
        else if (_itemType.intValue == 2)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_isEquipped, new GUIContent("Equipped"));
            EditorGUILayout.PropertyField(_armorType, new GUIContent("Armor Type"));
            EditorGUILayout.PropertyField(_armorDefence, new GUIContent("Armor Defence"));
            EditorGUI.indentLevel--;
        }
        else if (_itemType.intValue == 4)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_typeEffect, new GUIContent("Type Effect"));
            EditorGUILayout.PropertyField(_amountOfEffect, new GUIContent("Amount Of Effect"));
            EditorGUILayout.PropertyField(_isStackable, new GUIContent("Stackable"));
            if (_isStackable.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(_stackAmount, new GUIContent("Stack Amount"));
                EditorGUILayout.PropertyField(_maxStackAmount, new GUIContent("Max Stack Amount"));
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }

        serializedObject.ApplyModifiedProperties();
     
    }
}
#endif
