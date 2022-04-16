using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{
    public static DialogHandler instance;

    [SerializeField] string villagerName;
    [SerializeField] int villagerID=0;

    public string[] sentences;
    bool canActivateBox;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (canActivateBox && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            EventManager.OnConversationStartEvent(sentences,villagerID,villagerName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivateBox = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivateBox = false;
        }
    }
}
