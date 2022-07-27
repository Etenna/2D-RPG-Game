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
    [SerializeField] GameObject characterCoiceButton;
    [SerializeField] GameObject itemsButton;

    [Header("Stat Panel")]
    [SerializeField] GameObject charInformationObject;
    [SerializeField] GameObject[] stateCharButtons;

    [SerializeField] TextMeshProUGUI statCharName, statCharLevel, statCharHP, statCharMP, statCharStrength, statCharVitality, 
        statCharDexterity, statCharWisdom, statCharSpeed, statCharDefense, statEquippedArmor, statEquippedWeapon,statCharWeaponPower,statCharArmorDefence;
    [SerializeField] Image statCharImage;

    [Header("Item Slot")]
    [SerializeField] GameObject itemSlotContainer;
    [SerializeField] Transform itemSlotContainerParent;
    [SerializeField] TextMeshProUGUI itemEquipped;
    public TextMeshProUGUI itemName, itemDescription;


    [Header("Character Choice")]
    [SerializeField] GameObject characterChoicePanel;
    [SerializeField] TextMeshProUGUI[] itemsCharacterChoiceNames;

    public GameObject useButton;
    public ItemData activeItem;


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
        if (Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.I))
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
            charHPText[i].text = $"HP: {playerStats[i].GetPlayerCurrentHealth()}/{playerStats[i].GetPlayerMaxHealth()}";
            charMPText[i].text = $"MP: {playerStats[i].GetPlayerCurrentMana()}/{playerStats[i].GetPlayerMaxMana()}";
            charCurrentXP[i].text = $"Current XP: {playerStats[i].GetPlayerCurrentXP()}";
            charXPText[i].text = $"{playerStats[i].GetPlayerCurrentXP()}/{playerStats[i].GetPlayerXPForNextLevel()}";

            charXPValuePrecentage[i].text = $"{Mathf.FloorToInt(playerStats[i].GetPlayerCurrentXP() / playerStats[i].GetPlayerXPForNextLevel()*100)}%";
            XPSlider[i].value = playerStats[i].GetPlayerCurrentXP() / playerStats[i].GetPlayerXPForNextLevel()*100;

            charImage[i].sprite = playerStats[i].GetPlayerSprite();
        }
    }
    public void StatsMenu()
    {
        foreach (var item in stateCharButtons)
        {
            SetMenuPanelStatus(false, item);
        }
        for (int i = 0; i < playerStats.Length; i++)
        {
            SetMenuPanelStatus(true, stateCharButtons[i]);

            stateCharButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = playerStats[i].GetPlayerName();
        }
        UpdateStatePanel(0);
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
    public IEnumerator SelectedFirstButton(GameObject buttonToSelect, params GameObject[] button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(buttonToSelect);
    }
    public void UpdateStatePanel(int playerSelectedNumber)
    {
        PlayerStats playerSelected=playerStats[playerSelectedNumber];

        statCharName.text = playerSelected.GetPlayerName();
        statCharLevel.text = playerSelected.GetPlayerLevel().ToString();

        statCharHP.text = $"{playerSelected.GetPlayerCurrentHealth()}/{playerSelected.GetPlayerMaxHealth()}";
        statCharMP.text= $"{playerSelected.GetPlayerCurrentMana()}/{playerSelected.GetPlayerMaxMana()}";

        statCharStrength.text= playerSelected.GetPlayerStrength().ToString();
        statCharVitality.text= playerSelected.GetPlayerVitality().ToString();
        statCharDexterity.text = playerSelected.GetPlayerDexterity().ToString();
        statCharWisdom.text= playerSelected.GetPlayerWisdom().ToString();

        statCharSpeed.text= playerSelected.GetPlayerSpeed().ToString();
        statCharDefense.text = playerSelected.GetPlayerDefence().ToString();

        statCharImage.sprite = playerSelected.GetPlayerSprite();

        statEquippedWeapon.text=playerSelected.GetEquippedWeaponName();
        statEquippedArmor.text=playerSelected.GetEquippedArmorName();

        //statCharWeaponPower.text = playerSelected.GetWeaponDamage().ToString();
        //statCharArmorDefence.text = playerSelected.GetArmorDefence().ToString();
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
            StartCoroutine(SelectedFirstButton(stateCharButtons[0]));
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
   
    public void UpdateItemsInventory()
    {

        foreach (Transform itemSlot in itemSlotContainerParent)
        {
            Destroy(itemSlot.gameObject);
        }

        foreach (ItemData item in Inventory.Instance.GetItemsList())
        {
            RectTransform itemSlot = Instantiate(itemSlotContainer, itemSlotContainerParent).GetComponent<RectTransform>();

            Image itemImage = itemSlot.Find("Image").GetComponent<Image>();
            itemImage.sprite = item.ItemImage;

            TextMeshProUGUI itemText=itemSlot.Find("Amount").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI equippedText = itemSlot.Find("Equipped").GetComponent<TextMeshProUGUI>();

            if (item.IsStackable)
            {
                itemText.text = $"{item.StackAmount}";
            }
            else
            {
                itemText.text = $"";
            }

            // TODO Wenn Item Equipt wurde, aktiviere E Text.

            itemSlot.GetComponent<InventoryItemDescription>().itemOnButton=item;

            if (item.IsEquipped)
            {
                equippedText.gameObject.SetActive(true);
            }
            else if (!item.IsEquipped)
            {
                equippedText.gameObject.SetActive(false);
            }
        }
    }

    public void DiscardItem()
    {
        Debug.Log(activeItem.ItemName);
        Inventory.Instance.RemoveItem(activeItem);
        UpdateItemsInventory();
    }

    public void UseItem(int selectedCharacter)
    {
        activeItem.UseItem(selectedCharacter);
        StartCoroutine(SelectedFirstButton(itemsButton));
        UpdateStats();

        switch (activeItem.Type)
        {
            case ItemData.ItemType.Armor:
                Debug.Log("Armor selected");
                break;
            case ItemData.ItemType.Weapon:
                Debug.Log("Weapon selected");
                break;

        }

        if (!activeItem.IsEquipped && activeItem.Type == ItemData.ItemType.Armor || !activeItem.IsEquipped && activeItem.Type == ItemData.ItemType.Weapon)
        {
            activeItem.IsEquipped = true;
            UpdateItemsInventory();
            return;
        }
        if (activeItem.IsEquipped && activeItem.Type == ItemData.ItemType.Armor || activeItem.IsEquipped && activeItem.Type == ItemData.ItemType.Weapon)
        {
            activeItem.IsEquipped = false;
            UpdateItemsInventory();
            return;
        }
        DiscardItem();
    
    }

    public void OpenCharacterChoicePanel()
    {
        characterChoicePanel.SetActive(true);

        if (activeItem)
        {
            StartCoroutine(SelectedFirstButton(characterCoiceButton));
            for (int i = 0; i < playerStats.Length; i++)
            {
                PlayerStats activePlayer = GameManager.instance.GetPlayerStats()[i];
                itemsCharacterChoiceNames[i].text=activePlayer.GetPlayerName();

                bool activePlayerAvailable = activePlayer.gameObject.activeInHierarchy;
                itemsCharacterChoiceNames[i].transform.parent.gameObject.SetActive(activePlayerAvailable);
            }
        }
    }
    public void CloseCharacterChoicePanel()
    {
        characterChoicePanel.SetActive(false);
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
