
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SceneChange());
        }
    }

    IEnumerator SceneChange()
    {
        PlayerController.instance.transitionName = transitionAreaName;
        EventManager.Instance.OnSceneFadeOutEvent();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToLoad);
        EventManager.Instance.OnSceneFadeInEvent();
    }
}
