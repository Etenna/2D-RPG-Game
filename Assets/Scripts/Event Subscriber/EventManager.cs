using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Dies ist die Hauptklasse der Events. Hier werden die Events, auf denen man Subscriben kann erstellt.
/// Dazu wird die nötige Invoke Methode bereit gestellt.
/// </summary>
public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public delegate void OnConversationStartDelegate(TextAsset inkJSON,string villagerName);
    public static event OnConversationStartDelegate OnConversationStart;

    public static void OnConversationStartEvent(TextAsset inkJSON, string villagerName)
    {
        HandlePlayerMovementInput(true);
        OnConversationStart?.Invoke(inkJSON,villagerName);
    }
    public static event Action OnConversationEnd;
    public static void OnConversationEndEvent()
    {
        OnConversationEnd?.Invoke();
        HandlePlayerMovementInput(false);
    }
    public static event Action<bool> HandlePlayerMovementInput;
    public void HandlePlayerMovementInputEvent()
    {
        HandlePlayerMovementInput?.Invoke(true);
    }
    public static event Action OnPlayerDied;
    public void OnPlayerDiedEvent()
    {
        OnPlayerDied?.Invoke();
    }

    public static event Action OnSceneChanged;
    public void OnSceneChangedEvent()
    {
        OnSceneChanged?.Invoke();
    }

    

    #region Fading Event
    public static event Action OnSceneFadeIn;
    public void OnSceneFadeInEvent()
    {
        Debug.Log("Start FadeIn Event");
        OnSceneFadeIn?.Invoke();
    }

    public static event Action OnSceneFadeOut;
    public void OnSceneFadeOutEvent()
    {
        Debug.Log("Start FadeOut Event");
        OnSceneFadeOut?.Invoke();
    }
    #endregion

    #region TestEvent
    /// <summary>
    /// Wird gegen schluss wieder gelöscht. Dient zum nachschauen wie ein Event erstellt wird.
    /// </summary>
    //public delegate void OnPressSpezificKey();
    //public static event OnPressSpezificKey onPressSpezificKey;
    //public static void PressSpezificKey()
    //{
    //    onPressSpezificKey?.Invoke();
    //}
    #endregion
}
