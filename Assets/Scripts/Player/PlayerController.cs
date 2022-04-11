using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float playerMovementSpeed = 5f;
    [SerializeField] Rigidbody2D playerRb;

    Vector2 movementInput;
    Animator playerAnimator;

    public string transitionName;

    Vector3 bottomLeftEdge;
    Vector3 topRightEdge;

    [SerializeField] Tilemap tilemap;
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
        //tilemap.ResizeBounds();
        bottomLeftEdge = tilemap.localBounds.min;
        topRightEdge = tilemap.localBounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Debug.Log(bottomLeftEdge.y);
        Debug.Log(bottomLeftEdge.x);
        Debug.Log(bottomLeftEdge.z);
        SetPlayerInsideTheMap();

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");


        movementInput.Normalize();
        playerRb.velocity = movementInput * playerMovementSpeed;

        SetPlayerWalkAndIdleAnimation();

    }

    private void SetPlayerInsideTheMap()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
            Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
            Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)
        );
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(tilemap.localBounds.min, tilemap.localBounds.max);
    }
}