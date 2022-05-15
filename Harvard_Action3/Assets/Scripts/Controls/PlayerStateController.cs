using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public const float MARBLE = 0f;
    public const float MALLEABLE = 1f;
    public const float BUBBLE = 2f;
    public const float BUBBLE_FLOATING = 3f;
    public const float BUBBLE_FLOATING_TEMP_RANGE = 10f;

    public float bubbleStartHeat;

    public float state;

    void Start() {
        state = MARBLE;
    }

    public void setState(float newState) {
        state = newState;
    }
}
