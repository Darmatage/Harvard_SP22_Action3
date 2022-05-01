using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Movement
{
    public class SolidFormMovement : MonoBehaviour
    {
        private float movementSpeed;
        private Rigidbody2D particleRigidbody;
        private CircleCollider2D particleCircleCollider;
        private Vector2 moveInput;
        private Vector2 lookDirection = new Vector2(1,0);
        private PlayerMovement playerMovement;

        private void Awake() 
        {
            playerMovement = GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<PlayerMovement>();
            particleRigidbody = GetComponent<Rigidbody2D>();
            particleCircleCollider = GetComponent<CircleCollider2D>();
        }

        private void Start()
        {
            movementSpeed = playerMovement.GetSolidMovementSpeed();
        }


        private void FixedUpdate()
        {
            SolidMove(playerMovement.GetMoveInput());
        }

        public void SolidMove(Vector2 inputMovement)
        {
            Vector2 particleVelocity = new Vector2 (inputMovement.x * movementSpeed, particleRigidbody.velocity.y);
            particleRigidbody.velocity = particleVelocity;

            if(!Mathf.Approximately(inputMovement.x, 0.0f) || !Mathf.Approximately(inputMovement.y, 0.0f))
            {
                lookDirection.Set(inputMovement.x, inputMovement.y);
                lookDirection.Normalize();
            }

        }
    }
}

