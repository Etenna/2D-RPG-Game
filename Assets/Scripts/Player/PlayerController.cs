using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] Rigidbody2D playerRb;
        [SerializeField] float playerMovementSpeed = 5f;
        Vector2 movementInput;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.y = Input.GetAxisRaw("Vertical");

            movementInput.Normalize();  

            playerRb.velocity = movementInput * playerMovementSpeed;
        }
    }
}

