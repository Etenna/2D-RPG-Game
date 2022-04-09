using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] Rigidbody2D playerRb;
        [SerializeField] float playerMovementSpeed = 5f;

        Vector2 movementInput;
        Animator playerAnimator;
        private void Awake()
        {
            playerAnimator = GetComponent<Animator>();
        }
        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(this);
        }

        // Update is called once per frame
        void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.y = Input.GetAxisRaw("Vertical");


            movementInput.Normalize();
            playerRb.velocity = movementInput * playerMovementSpeed;

            SetPlayerWalkAndIdleAnimation();

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
    }
}

