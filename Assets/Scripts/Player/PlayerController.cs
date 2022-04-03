using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] Rigidbody2D playerRb;
        [SerializeField] float playerMovementSpeed = 5f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float horizontalMovement = Input.GetAxisRaw("Horizontal") * playerMovementSpeed * Time.deltaTime;
            float verticalMovement = Input.GetAxisRaw("Vertical") * playerMovementSpeed * Time.deltaTime;

            Debug.Log(horizontalMovement + " " + verticalMovement);
            playerRb.velocity = new Vector2(horizontalMovement, verticalMovement);
        }
    }
}

