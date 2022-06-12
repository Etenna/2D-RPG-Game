using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using System;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI villagerNameText;

    [Header("Choices UI")]
    [SerializeField] GameObject choicesPanel;
    [SerializeField] GameObject[] choices;
    TextMeshProUGUI[] choicesText;

    Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

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

    public static DialogueManager GetInstance()
    {
        return instance;
    }
    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        
        choicesText=new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index]=choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    private void Update()
    {
        if (!dialogueIsPlaying) return;
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            ContinueStory();
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON,string villagerName)
    {
        GameManager.instance.dialogBoxOpened = true;
        currentStory=new Story(inkJSON.text);
        dialogueIsPlaying = true;
        villagerNameText.text = villagerName;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        EventManager.OnConversationEndEvent();
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        GameManager.instance.dialogBoxOpened = false;
    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // Set Text for the current Dialogue Line
            dialogueText.text = currentStory.Continue();
            // Display choices, if any, for this Dialogue
            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count <= 0)
        {
            choicesPanel.SetActive(false);
            return;
        }
        else
        {
            choicesPanel.SetActive(true);
        }
        // Defensive check
        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError($"Es sind mehr Auswahlmöglichkeiten zu treffen, als das UI supporten kann: {currentChoices.Count}");
        }

        int index = 0;

        // Enable and Initialize the choices up to the amount of choices for this Line of Dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // Go through the remaining choices the UI supports and make sure they're hidden!
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }  
        StartCoroutine(SelectedFirstChoice());
    }

    IEnumerator SelectedFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    private void OnEnable()
    {
        EventManager.OnConversationStart += EnterDialogueMode;
    }
    private void OnDisable()
    {
        EventManager.OnConversationStart -= EnterDialogueMode;
    }
}
