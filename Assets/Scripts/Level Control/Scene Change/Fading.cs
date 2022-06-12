using UnityEngine;

public class Fading : MonoBehaviour
{
    public static Fading Instance;

    Animator fadeAnimator;

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
    // Start is called before the first frame update
    void Start()
    {
        fadeAnimator = GetComponentInChildren<Animator>();
    }
   
    private void PlayFadeIn()
    {
        fadeAnimator.Play("Base Layer.FadeIn");
    }

    private void PlayFadeOut()
    {
        fadeAnimator.Play("Base Layer.FadeOut");
    }

    private void OnEnable()
    {
        Debug.Log("Begin Subscribe 0/2");
        EventManager.OnSceneFadeIn += PlayFadeIn;
        Debug.Log("Begin Subscribe 1/2");
        EventManager.OnSceneFadeOut += PlayFadeOut;
        Debug.Log("Begin Subscribe 2/2");
    }
    private void OnDisable()
    {
        Debug.Log("Begin Unsubscribe 0/2");
        EventManager.OnSceneFadeOut -= PlayFadeOut;
        Debug.Log("Begin Unsubscribe 1/2");

        EventManager.OnSceneFadeIn -= PlayFadeIn;
        Debug.Log("Begin Unsubscribe 2/2");

    }
}
