using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class DoorOpener : MonoBehaviour
{
    BoxCollider2D collider2D;

    [SerializeField] Sprite[] doorSprites;
    bool isOpen;
    private void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        collider2D.isTrigger = true;
        GetComponent<SpriteRenderer>().sprite = doorSprites[0];
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            GetComponent<SpriteRenderer>().sprite = doorSprites[1];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Trigger Enter: {collision.name}");
        if (!isOpen && collision.CompareTag("Player"))
        {
            isOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOpen = false;
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = doorSprites[0];
    }
}
