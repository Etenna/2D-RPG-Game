using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] PlayerStats[] playerStats;


    public bool gameMenuOpened, dialogBoxOpened;

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


        FindPlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMenuOpened || dialogBoxOpened)
        {
            PlayerController.instance.DisableInput(true);
        }else
        {
            PlayerController.instance.DisableInput(false);
        }
    }
    public void FindPlayerStats()
    {
        playerStats=FindObjectsOfType<PlayerStats>();
    }

    public PlayerStats[] GetPlayerStats()
    {
        return playerStats;
    }
}
