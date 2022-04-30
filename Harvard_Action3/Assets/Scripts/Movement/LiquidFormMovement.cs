using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Movement
{
    public class LiquidFormMovement : MonoBehaviour
    {
        private float movementSpeed;
        private float climbLift;
        private Rigidbody2D particleRigidbody;
        private CircleCollider2D particleCircleCollider;
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
            movementSpeed = playerMovement.GetLiquidMovementSpeed();
            climbLift = playerMovement.GetLiquidClimbLift();
        }

        private void OnEnable()
        {
            EventHandler.ClimbActionEvent += Climb;
        }

        private void OnDisable()
        {
            EventHandler.ClimbActionEvent -= Climb;
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

        private void Climb() 
        {
            //if(!isAlive){ return; }
            if(!particleRigidbody.IsTouchingLayers(LayerMask.GetMask("ClimbSurface"))) return;

            if(lookDirection == Vector2.right)
            {
                //Debug.Log("Jump Right");
                particleRigidbody.velocity += new Vector2 (0f, climbLift);
            }

            if(lookDirection == Vector2.left)
            {
                //Debug.Log("Jump Left");
                particleRigidbody.velocity += new Vector2 (0f, climbLift);
            }
        }

    }
}

