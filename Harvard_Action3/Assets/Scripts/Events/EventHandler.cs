using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventHandler
{    

    // Pause game and controls while in UI
    public static event Action<bool> ActiveGameUI;
    public static void CallActiveGameUI(bool isGamePaused)
    {
        if (ActiveGameUI != null)
        {
            ActiveGameUI(isGamePaused);
        }
    }

    // Escape Action
    public static event Action EscapeActionEvent;
    public static void CallEscapeActionEvent()
    {
        if (EscapeActionEvent != null)
        {
            EscapeActionEvent();
        }
    }

    // Close All UI Action
    public static event Action CloseAllUIActionEvent;
    public static void CallCloseAllUIActionEvent()
    {
        if (CloseAllUIActionEvent != null)
        {
            CloseAllUIActionEvent();
        }
    }

    // Gameover Action
    public static event Action GameOverActionEvent;
    public static void CallGameOverActionEvent()
    {
        if (GameOverActionEvent != null)
        {
            GameOverActionEvent();
        }
    }

    // Climb Action
    public static event Action ClimbActionEvent;
    public static void CallClimbActionEvent()
    {
        if (ClimbActionEvent != null)
        {
            ClimbActionEvent();
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
