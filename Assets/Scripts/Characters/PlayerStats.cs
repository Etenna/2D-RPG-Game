using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    [Header("Character Info")]
    [SerializeField] Sprite playerSprite;
    [SerializeField] string playerName;
    [Header("Level Info")]
    [SerializeField] int playerLevel = 1;
    [SerializeField] float currentXP;
    [SerializeField] int maxLevel = 10;
    [SerializeField] int baseLevelXP = 100; // XP need for reach the second Level
    [SerializeField] float[] xpForEachLevel;

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

    [Header("XP Calculator")]
    [SerializeField] float xpCalc1 = 5.12f;
    [SerializeField] float xpCalc2 = 4.06f;
    [SerializeField] float xpCalc3 = 110.6f;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        xpForEachLevel = new float[maxLevel];
        xpForEachLevel[1] = baseLevelXP;
        CalculateXPForEachLevel();
    }

    private void CalculateXPForEachLevel()
    {
        for (int i = 2; i < xpForEachLevel.Length; i++)
        {
            xpForEachLevel[i] = Mathf.FloorToInt(xpCalc1 * i * i * i + xpCalc2 * i * i + xpCalc3 * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AddXP(20);
        }
    }

    public void AddXP(int amountOfXP)
    {
        currentXP += amountOfXP;
        if (currentXP > xpForEachLevel[playerLevel])
        {
            currentXP -= xpForEachLevel[playerLevel];
            OnLevelUp();

        }
    }

    public void SetMaxHealth(int amountToAdd)
    {
        maxHealth += amountToAdd;
    }

    void OnLevelUp()
    {
        playerLevel++;
        Debug.Log("Congratulation, you are earned enough XP to reach Level: " + playerLevel);
        AddStats();
    }
    void AddStats()
    {
        // TODO: Add different stats and calculating Methods
        maxHealth += 20;
    }

    public void AddMana(int amount)
    {
        currentMana += amount;
        if (currentMana > maxMana)
            currentMana = maxMana;
    }
    public void AddHP(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
    public int GetPlayerLevel() => playerLevel;
    public string GetPlayerName() => playerName;
    public int GetPlayerMaxHealth() => maxHealth;
    public int GetPlayerCurrentHealth() => currentHealth;
    public int GetPlayerMaxMana() => maxMana;
    public int GetPlayerCurrentMana()=> currentMana;
    public float GetPlayerCurrentXP() => currentXP;
    public float GetPlayerXPForNextLevel() => xpForEachLevel[playerLevel];
    public Sprite GetPlayerSprite() => playerSprite;
    public int GetPlayerStrength() => strength;
    public int GetPlayerVitality() => vitality;
    public int GetPlayerDexterity() => dexterity;
    public int GetPlayerDefence() => defence;
    public int GetPlayerWisdom() => wisdom;
    public int GetPlayerSpeed() => speed;
}
