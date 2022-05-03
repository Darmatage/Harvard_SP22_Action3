using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float soldiMovementSpeed = 5f;
        [SerializeField] float liquidMovementSpeed = 2.5f;
        [SerializeField] float liquidClimbLift = 5f;

        [SerializeField] GameObject solidContainer = null;
        [SerializeField] GameObject particleContainer = null;

        private GameObject player;
        private PlayerStateController playerStateController;

        private Rigidbody2D playerRigidbody;
        public Rigidbody2D GetPlayerRigidbody() { return playerRigidbody; }
        private Vector2 moveInput;
        private Vector2 lookDirection = new Vector2(1,0);
        public Vector2 GetPlayerVector2() { return lookDirection; }
        // private bool PlayerInputIsDisabled = false;
        // public AudioSource RollSFX;



        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerStateController = GetComponent<PlayerStateController>();
            //playerCircleCollider = GetComponent<CircleCollider2D>();
        }

        private void OnEnable()
        {
            EventHandler.StateChangeActionEvent += ChangeState;
        }

        private void OnDisable()
        {
            EventHandler.StateChangeActionEvent -= ChangeState;
        }

        void Start() 
        {
            player = GameObject.FindWithTag("Player");

            solidContainer.SetActive(true);
            particleContainer.SetActive(false);
        }

        private void FixedUpdate()
        {
            if (moveInput.x == 1) {
                if (playerStateController.state == PlayerStateController.MARBLE) {
                    player.transform.Rotate(0f, 0f, -10f, Space.Self);
                }
            } else if (moveInput.x == -1) {
                if (playerStateController.state == PlayerStateController.MARBLE) {
                    player.transform.Rotate(0f, 0f, 10f, Space.Self);
                }
            }
        }

        public void Move(InputAction.CallbackContext value)
        {
            moveInput = value.ReadValue<Vector2>();
        }

        public void Climb(InputAction.CallbackContext value) 
        {
            if(value.started)
            {
                EventHandler.CallClimbActionEvent();
            }
        }

        public float GetSolidMovementSpeed()
        {
            return soldiMovementSpeed;
        }

        public float GetLiquidMovementSpeed()
        {
            return liquidMovementSpeed;
        }

        public float GetLiquidClimbLift()
        {
            return liquidClimbLift;
        }

        public Vector2 GetMoveInput()
        {
            return moveInput;
        }

        // private void ParticleMove(Vector2 inputMovement)
        // {
        //     Vector2 particleVelocity = new Vector2 (inputMovement.x * movementSpeed, playerRigidbody.velocity.y);
        //     playerRigidbody.velocity = particleVelocity;

        //     if(!Mathf.Approximately(inputMovement.x, 0.0f) || !Mathf.Approximately(inputMovement.y, 0.0f))
        //     {
        //         lookDirection.Set(inputMovement.x, inputMovement.y);
        //         lookDirection.Normalize();
        //     }
        //     // if (!RollSFX.isPlaying){
        //     //   RollSFX.Play();
        //     // }
        //     // else {
        //     //   RollSFX.Stop();
        //     // }
        // }

        private void ChangeState()
        {
            if (solidContainer.activeSelf)
            {
                solidContainer.SetActive(false);
                particleContainer.SetActive(true);
            }
            else if (particleContainer.activeSelf)
            {
                particleContainer.SetActive(false);
                solidContainer.SetActive(true);
            }

        }
    }
}
