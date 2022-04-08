using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float movementSpeed = 5f;

        private Rigidbody2D playerRigidbody;
        public Rigidbody2D GetPlayerRigidbody() { return playerRigidbody; }
        private CircleCollider2D playerCircleCollider;
        private Vector2 moveInput;
        private Vector2 lookDirection = new Vector2(1,0);
        public Vector2 GetPlayerVector2() { return lookDirection; }
        private bool PlayerInputIsDisabled = false;

        private void Awake() 
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerCircleCollider = GetComponent<CircleCollider2D>();
        }

        private void FixedUpdate()
        {
            ParticleMove(moveInput);
        }
        
        public void Move(InputAction.CallbackContext value)
        {
            moveInput = value.ReadValue<Vector2>();            
        }

        private void ParticleMove(Vector2 inputMovement)
        {
            Vector2 particleVelocity = new Vector2 (inputMovement.x * movementSpeed, playerRigidbody.velocity.y);
            playerRigidbody.velocity = particleVelocity;

            if(!Mathf.Approximately(inputMovement.x, 0.0f) || !Mathf.Approximately(inputMovement.y, 0.0f))
            {
                lookDirection.Set(inputMovement.x, inputMovement.y);
                lookDirection.Normalize();
            }

        }
    }
}

