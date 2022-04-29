using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Movement
{
    public class ParticleMovement : MonoBehaviour
    {
        private float movementSpeed;
        private float jumpSpeed;
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
            movementSpeed = playerMovement.GetMovementSpeed();
            jumpSpeed = playerMovement.GetJumpSpeed();
        }

        private void OnEnable()
        {
            EventHandler.JumpActionEvent += Jump;
        }

        private void OnDisable()
        {
            EventHandler.JumpActionEvent -= Jump;
        }

        private void FixedUpdate()
        {
            ParticleMove(playerMovement.GetMoveInput());
        }

        public void ParticleMove(Vector2 inputMovement)
        {
            Vector2 particleVelocity = new Vector2 (inputMovement.x * movementSpeed, particleRigidbody.velocity.y);
            particleRigidbody.velocity = particleVelocity;

            if(!Mathf.Approximately(inputMovement.x, 0.0f) || !Mathf.Approximately(inputMovement.y, 0.0f))
            {
                lookDirection.Set(inputMovement.x, inputMovement.y);
                lookDirection.Normalize();
            }

        }

        public void Jump() 
        {
            //if(!isAlive){ return; }
            if(!particleRigidbody.IsTouchingLayers(LayerMask.GetMask("JumpSurface"))) return;

            if(lookDirection == Vector2.right)
            {
                //Debug.Log("Jump Right");
                particleRigidbody.velocity += new Vector2 (0f, jumpSpeed);
            }

            if(lookDirection == Vector2.left)
            {
                //Debug.Log("Jump Left");
                particleRigidbody.velocity += new Vector2 (0f, jumpSpeed);
            }
        }
    }
}

