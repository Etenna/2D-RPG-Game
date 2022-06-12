using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] GameObject menu;

    bool menuActive = false;
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            ShowMenu();
        }
    }

    private void ShowMenu()
    {
        if (menu.activeInHierarchy)
        {
            EventManager.OnMenuCloseEvent();
            menu.gameObject.SetActive(false);
        }
        else
        {
            EventManager.OnMenuShowEvent();
            menu.gameObject.SetActive(true);
        }
    }
}
