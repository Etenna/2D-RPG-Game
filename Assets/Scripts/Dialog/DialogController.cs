using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogText, nameText;
    [SerializeField] GameObject dialogBox, nameBox;

    [SerializeField] string[] dialogSentences;
    [SerializeField] int currentSentence=0;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        nameBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartConservation();

        }
        if (dialogBox.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            ContinueConservation();
        }
    }

    private void StartConservation()
    {
        currentSentence = 0;
        dialogBox.SetActive(true);
        nameBox.SetActive(true);
        dialogText.text = dialogSentences[currentSentence];
        Debug.Log($"Starte Gespr�ch. Aktuelles Element im Array: {currentSentence}/{dialogSentences.Length}");
    }

    void ContinueConservation()
    {
        currentSentence++;
        Debug.Log($"Aktuelles Element im Array: {currentSentence}/{dialogSentences.Length}");
        Debug.Log($"CurrentSentence Element: {currentSentence}");
        if (currentSentence >= dialogSentences.Length)
        {
            dialogBox.SetActive(false);
            nameBox.SetActive(false);
            //currentSentence = 0;
            return;
        }
        dialogText.text = dialogSentences[currentSentence];
    }
}
