using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventHandler
{    
    // Jump Action
    public static event Action JumpActionEvent;
    public static void CallJumpActionEvent()
    {
        if (JumpActionEvent != null)
        {
            JumpActionEvent();
        }
    }

    // Transform Action
    public static event Action StateChangeActionEvent;
    public static void CallStateChangeActionEvent()
    {
        if (StateChangeActionEvent != null)
        {
            StateChangeActionEvent();
        }
    }

    // Add Particle Event
    public static event Action AddParticleEvent;
    public static void CallAddParticleEvent()
    {
        if (AddParticleEvent != null)
        {
            AddParticleEvent();
        }
    }
}
