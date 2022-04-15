using System;
using System.Collections;
using System.Collections.Generic;
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
