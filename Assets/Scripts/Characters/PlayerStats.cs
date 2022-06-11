using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    [Header("Character Info")]
    [SerializeField] string playerName;
    [Header("Level Info")]
    [SerializeField] int playerLevel=1;
    [SerializeField] int currentXP;
    [SerializeField] int maxLevel=10;
    [SerializeField] int baseLevelXP = 100; // XP need for reach the second Level
    [SerializeField] int[] xpForEachLevel;

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
        xpForEachLevel = new int[maxLevel];
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
        currentXP+=amountOfXP;
        if(currentXP > xpForEachLevel[playerLevel])
        {
            currentXP-=xpForEachLevel[playerLevel];
            OnLevelUp();

        }
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }
    public void SetMaxHealth(int amountToAdd)
    {
        maxHealth+=amountToAdd;
    }

    void OnLevelUp()
    {
        playerLevel++;
        Debug.Log("Congratulation, you are earned enough XP to reach Level: "+playerLevel);
        AddStats();
    }
    void AddStats()
    {
        maxHealth += 20;
    }
}
