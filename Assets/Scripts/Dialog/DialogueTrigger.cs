using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] GameObject visualCue=null;

    [Header("Ink JSON")]
    [SerializeField] TextAsset inkJSON=null;

    [Header("Villager Information")]
    [SerializeField] VillagerController villager;
    bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange&&!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                // Hier wird dann das Eventabgefeuert!
                //DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                EventManager.OnConversationStartEvent(inkJSON,villager.GetVillagerName());
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
