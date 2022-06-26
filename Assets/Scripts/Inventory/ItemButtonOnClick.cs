using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemButtonOnClick : MonoBehaviour
{
    [SerializeField] GameObject useButton;

    private void Start()
    {
        useButton = MenuManager.instance.useButton;
    }
    public void ButtonOnClick()
    {
        StartCoroutine(MenuManager.instance.SelectedFirstButton(useButton));
    }
}
