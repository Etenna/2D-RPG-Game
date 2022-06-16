using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] GameObject menu;

    bool menuActive = false;

    [Header("Character Panel")]
    PlayerStats[] playerStats;
    [SerializeField] TextMeshProUGUI[] charNameText, charHPText, charMPText, charCurrentXP, charXPText, charXPValuePrecentage;
    [SerializeField] Slider[] XPSlider;
    [SerializeField] Image[] charImage;
    [SerializeField] GameObject[] charPanel;

    [Header("Panels")]
    [SerializeField] GameObject itemPanel, statPanel;

    [Header("Buttons")]
    [SerializeField] GameObject overviewButton;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
        menu.gameObject.SetActive(false);
    }
    void Start()
    {
        itemPanel.SetActive(false);
        statPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.dialogBoxOpened) return;
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            ShowMenu();
        }
    }
    public void UpdateStats()
    {
        playerStats = GameManager.instance.GetPlayerStats();

        foreach (var item in charPanel)
        {
            item.SetActive(false);
        }
        foreach (var item in XPSlider)
        {
            item.minValue = 0;
            item.maxValue = 100;
        }

        for (int i = 0; i < playerStats.Length; i++)
        {
            charPanel[i].SetActive(true);

            charNameText[i].text = playerStats[i].GetPlayerName();
            charHPText[i].text = $"HP: {playerStats[i].GetCurrentHealth()}/{playerStats[i].GetMaxHealth()}";
            charMPText[i].text = $"MP: {playerStats[i].GetCurrentMana()}/{playerStats[i].GetMaxMana()}";
            charCurrentXP[i].text = $"Current XP: {playerStats[i].GetCurrentXP()}";
            charXPText[i].text = $"{playerStats[i].GetCurrentXP()}/{playerStats[i].GetXPForNextLevel()}";

            charXPValuePrecentage[i].text = $"{Mathf.FloorToInt(playerStats[i].GetCurrentXP() / playerStats[i].GetXPForNextLevel()*100)}%";
            XPSlider[i].value = playerStats[i].GetCurrentXP() / playerStats[i].GetXPForNextLevel()*100;

            charImage[i].sprite = playerStats[i].GetPlayerSprite();
        }
    }

    public void ShowMenu()
    {
        if (menu.activeInHierarchy)
        {
            EventManager.OnMenuCloseEvent();
            menu.gameObject.SetActive(false);
            GameManager.instance.gameMenuOpened = false;
        }
        else
        {
            GameManager.instance.FindPlayerStats();
            UpdateStats();
            EventManager.OnMenuShowEvent();
            menu.gameObject.SetActive(true);
            GameManager.instance.gameMenuOpened = true;

            StartCoroutine(SelectedFirstButton());
        }
    }
    IEnumerator SelectedFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(overviewButton);
    }
    public void ShowItemPanel()
    {
        if (!itemPanel.activeInHierarchy)
        {
            statPanel.SetActive(false);
            itemPanel.SetActive(true);
        }
    }
    public void ShowStatPanel()
    {
        if (!statPanel.activeInHierarchy)
        {
            itemPanel.SetActive(false);
            statPanel.SetActive(true);
        }
    }
    public void ShowOverview()
    {
        itemPanel.SetActive(false);
        statPanel.SetActive(false);
    }
   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application is quitting right now!");
    }
}
