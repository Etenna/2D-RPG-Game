using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In dieser Klasse wird auf Ereignis reagiert, zum Beispiel auf Tasteneingabe etc.
/// 
/// </summary>
public class EventHandler : MonoBehaviour
{
    public static EventHandler Instance;
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


    // Update is called once per frame
    void Update()
    {

    }

    #region TestEvent feuern
    /// <summary>
    /// Methode zum feuern eines Events
    /// </summary>
    //private static void TestMethodToFireAEvent()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        EventManager.PressSpezificKey();
    //    }
    //}
    #endregion
}
