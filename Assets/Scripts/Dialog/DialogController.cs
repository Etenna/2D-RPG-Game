using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public static DialogController Instance;

    [SerializeField] TextMeshProUGUI dialogText, nameText;
    [SerializeField] GameObject dialogBox, nameBox;

    [SerializeField] string[] dialogSentences;
    [SerializeField] int currentSentence=0;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void StartConversation()
    {
        if (!dialogBox.activeInHierarchy)
        {
            currentSentence = 0;
            dialogBox.SetActive(true);
            nameBox.SetActive(true);
           
            //dialogText.text = dialogSentences[currentSentence];
        }
        else
        {
            currentSentence++;

            if (currentSentence >= dialogSentences.Length)
            {
                dialogBox.SetActive(false);
                nameBox.SetActive(false);

                return;
            }

            dialogText.text = dialogSentences[currentSentence];
        }
    }

    public void ActivateDialog(string[] newSentencesToUse,int id,string villagerName)
    {

        if (!dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(true);

            nameText.text = villagerName;

            dialogSentences = newSentencesToUse;
            currentSentence = 0;

            dialogText.text = dialogSentences[currentSentence];
        }
        else
        {
            currentSentence++;

            if (currentSentence >= dialogSentences.Length)
            {
                dialogBox.SetActive(false);

                EventManager.OnConversationEndEvent();
                return;
            }

            dialogText.text = dialogSentences[currentSentence];
        }
     
    }
    //IEnumerator TypeWritter(string dialog, TMP_Text textLabel)
    //{
    //    float t = 0;
    //    int charIndex = 0;
    //    while (charIndex < dialog.Length)
    //    {
    //        t+=Time.deltaTime;
    //        charIndex=Mathf.FloorToInt(t);
    //        charIndex=Mathf.Clamp(charIndex, 0, dialog.Length);

    //        textLabel.text = dialog.Substring(0, charIndex);

    //        yield return null;
    //        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    //    }

    //    textLabel.text = dialog;
    //}

    private void OnEnable()
    {
        EventManager.OnConversationStart += ActivateDialog;
    }
    private void OnDisable()
    {
        EventManager.OnConversationStart -= ActivateDialog;
    }
}
