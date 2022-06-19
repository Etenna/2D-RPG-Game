using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemData))]
public class ItemDataEditor : Editor
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
            EditorGUI.indentLevel--;
        }
        else if (_itemType.intValue == 2)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_armorType, new GUIContent("Armor Type"));
            EditorGUILayout.PropertyField(_armorDefence, new GUIContent("Armor Defence"));
            EditorGUI.indentLevel--;
        }
        else if (_itemType.intValue == 4)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_typeEffect, new GUIContent("Type Effect"));
            EditorGUILayout.PropertyField(_amountOfEffect, new GUIContent("Amount Of Effect"));
            EditorGUI.indentLevel--;
        }

        serializedObject.ApplyModifiedProperties();
     
    }
}
