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
        EventManager.OnSceneFadeIn += PlayFadeIn;
        EventManager.OnSceneFadeOut += PlayFadeOut;
    }
    private void OnDisable()
    {
        EventManager.OnSceneFadeOut -= PlayFadeOut;
        EventManager.OnSceneFadeIn -= PlayFadeIn;
    }
}
