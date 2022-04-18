using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Character Info")]
    [SerializeField] string playerName;
    [SerializeField] int playerLevel=1;
    [SerializeField] int currentXP;

    [Header("Health and Mana Info")]
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] int maxMana = 20;
    [SerializeField] int currentMana;

    [Header("Attributes")]
    [SerializeField] int strength;
    [SerializeField] int vitality;
    [SerializeField] int dexterity;
    [SerializeField] int speed;
    [SerializeField] int wisdom;
    [SerializeField] int defence;
    [SerializeField] int luck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
