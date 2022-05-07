using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public const int MARBLE = 0;
    public const int MALLEABLE = 1;
    public const int BUBBLE = 2;
    public const int BUBBLE_FLOATING = 3;
    public const int BUBBLE_FLOATING_TEMP_RANGE = 3;

    public int bubbleStartHeat;

    public int state;

    void Start() {
        state = MARBLE;
    }

    public void setState(int newState) {
        state = newState;
    }
}
