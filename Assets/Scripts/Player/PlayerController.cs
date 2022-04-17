using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float playerMovementSpeed = 5f;
    [SerializeField] Rigidbody2D playerRb;

    Vector2 movementInput;
    Animator playerAnimator;

    public string transitionName;
    bool disableInput = false;
    private void Awake()
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
        playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Debug.Log($"Movement Input Disabled: {disableInput}");

        if (disableInput)
        {
            SetPlayerInIdleMotion();
            return;
        }


        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput.Normalize();
        playerRb.velocity = movementInput * playerMovementSpeed;

        SetPlayerWalkAndIdleAnimation();
    }

    private void SetPlayerInIdleMotion()
    {
        playerAnimator.SetFloat("movementX", playerRb.velocity.x);
        playerAnimator.SetFloat("movementY", playerRb.velocity.y);
        playerRb.velocity = Vector2.zero;
    }

    private void SetPlayerWalkAndIdleAnimation()
    {
        playerAnimator.SetFloat("movementX", playerRb.velocity.x);
        playerAnimator.SetFloat("movementY", playerRb.velocity.y);

        if (movementInput.x == 1 || movementInput.x == -1 || movementInput.y == 1 || movementInput.y == -1)
        {
            playerAnimator.SetFloat("lastX", movementInput.x);
            playerAnimator.SetFloat("lastY", movementInput.y);
        }
    }
    void DisableInput(bool IsInputDisabled)
    {
        disableInput = IsInputDisabled;
    }

    private void OnEnable()
    {
        EventManager.HandlePlayerMovementInput += DisableInput;
    }
    private void OnDisable()
    {
        EventManager.HandlePlayerMovementInput -= DisableInput;
    }
    #region TestEvent Methoden welche auf das Event subscriben
    /// <summary>
    /// 2 Test Methoden, welche auf das TestEvent Subscriben.
    /// </summary>
    //void YouDied()
    //{
    //    Debug.Log("Method from PlayerController, Name: YouDied");
    //}
    //void YouNotDied()
    //{
    //    Debug.Log("You are not died..");
    //}
    //private void OnEnable()
    //{
    //    EventManager.onPressSpezificKey += YouDied;
    //    EventManager.onPressSpezificKey += YouNotDied;
    //}
    //private void OnDisable()
    //{
    //    EventManager.onPressSpezificKey -= YouDied;
    //    EventManager.onPressSpezificKey-= YouNotDied;
    //}
    #endregion
}