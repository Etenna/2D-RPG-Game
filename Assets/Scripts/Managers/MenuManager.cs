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

    [Header("Stat Panel")]
    [SerializeField] GameObject charInformationObject;
    [SerializeField] GameObject[] stateCharPanels;
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
    }
    void Start()
    {
        SetMenuPanelStatus(false,menu,itemPanel, statPanel,charInformationObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.dialogBoxOpened) return;
        if (Input.GetKeyDown(KeyCode.Joystick1Button7)||Input.GetKeyDown(KeyCode.I))
        {
            ShowMenu();
        }
    }
    public void UpdateStats()
    {
        playerStats = GameManager.instance.GetPlayerStats();

        foreach (var item in charPanel)
        {
            SetMenuPanelStatus(false, item);
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
    public void StatsMenu()
    {
        foreach (var item in stateCharPanels)
        {
            SetMenuPanelStatus(false, item);
        }
        for (int i = 0; i < playerStats.Length; i++)
        {
            SetMenuPanelStatus(true, stateCharPanels[i]);
        }
    }
    public void ShowMenu()
    {
        if (menu.activeInHierarchy)
        {
            EventManager.OnMenuCloseEvent();
            SetMenuPanelStatus(false, menu,itemPanel, charInformationObject, statPanel);
            GameManager.instance.gameMenuOpened = false;
        }
        else
        {
            GameManager.instance.FindPlayerStats();
            UpdateStats();
            EventManager.OnMenuShowEvent();
            SetMenuPanelStatus(true, menu);
            GameManager.instance.gameMenuOpened = true;

            StartCoroutine(SelectedFirstButton(overviewButton));
        }
    }
    IEnumerator SelectedFirstButton(GameObject buttonToSelect, params GameObject[] button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(buttonToSelect);
    }
    public void ShowItemPanel()
    {
        if (!itemPanel.activeInHierarchy)
        {
            SetMenuPanelStatus(false, statPanel);
            SetMenuPanelStatus(true, itemPanel);
        }
    }
    public void ShowStatPanel()
    {
        if (!statPanel.activeInHierarchy)
        {
            SetMenuPanelStatus(false, itemPanel);
            SetMenuPanelStatus(true, statPanel);
            StatsMenu();
            StartCoroutine(SelectedFirstButton(stateCharPanels[0]));
        }
    }
    public void ShowOverview()
    {
        SetMenuPanelStatus(false, itemPanel, statPanel, charInformationObject);
    }

    public void LoadCharInformation()
    {
        SetMenuPanelStatus(true, charInformationObject);
    }
   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application is quitting right now!");
    }

    private void SetMenuPanelStatus(bool isActive, params GameObject[] menuPanel)
    {
        foreach (var item in menuPanel)
        {
            item.SetActive(isActive);
        }
    }
}
