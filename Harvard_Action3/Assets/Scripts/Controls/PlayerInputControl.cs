using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Control
{
    public class PlayerInputControl : MonoBehaviour
    {
        public void EscapeAction(InputAction.CallbackContext value) //<- M Key
        {
            if (value.started)
            {
                Debug.Log("Esc Key is pressed!");
            }
        }
        public void StateChangeAction(InputAction.CallbackContext value) //<- M Key
        {
            if (value.started)
            {
                Debug.Log("State Change!");
            }
        }
    }
}

