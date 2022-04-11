
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AreaExit : MonoBehaviour
{

    [SerializeField] string sceneToLoad;    // Für Test
    [SerializeField] string transitionAreaName;
    [SerializeField] AreaEnter theAreaEnter;
    // Start is called before the first frame update
    void Start()
    {
        theAreaEnter.transitionAreaName = transitionAreaName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Nur für Testzwecke!
            // TODO: Ändern dass der Buildindex (int) geladen wird
            PlayerController.instance.transitionName = transitionAreaName;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
