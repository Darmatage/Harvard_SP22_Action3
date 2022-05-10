using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarbleScaleController : MonoBehaviour
{
    private GameObject player;
    private PlayerStateController playerStateController;
    private Rigidbody2D rigidBody;

    private bool isPlayerDead = false;
    public int particleTriggerCount = 0;

    private bool isGrowing = false;
    private bool isShrinking = false;
    private Vector3 scaleChange;
    private Vector2 upForce;

    float minSize = 1f;
    float maxSize = 3f;
    float scale = 1f;
    float scaleRate = 1f;
    int heatRate = 1;

    private GameHandler gameHandler;
    private TemperatureManager temperatureManager;
    private bool isLighterThanAir = false;
    private bool isFloating = false;
    public float thrust = 30f;

    // cooling off
    private int heatingTimer = 0;
    private int coolingTimer = 0;

    private int floatingTimer = 0;

    void Start() {
        if (GameObject.FindWithTag("GameHandler") != null){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }

        player = GameObject.FindWithTag("Player");
        playerStateController = player.GetComponent<PlayerStateController>();
        temperatureManager = player.GetComponent<TemperatureManager>();
        rigidBody = player.GetComponent<Rigidbody2D>();
        scaleChange = new Vector3(1f, 1f, 1f);
    }

    private void Update() {
        if (temperatureManager.Heat == 0) 
        {
            if(!isPlayerDead)
            {
                isPlayerDead = true;
                EventHandler.CallPlayerDeathEvent();
            }
        }
    }

    void FixedUpdate() {
        switch (playerStateController.state) {
            case PlayerStateController.MARBLE:
                if (temperatureManager.Heat > TemperatureManager.MARBLE_MAX_HEAT) {
                    playerStateController.setState(PlayerStateController.MALLEABLE);
                    EventHandler.CallStateChangeActionEvent();
                }
                break;
            case PlayerStateController.MALLEABLE:
                if (temperatureManager.Heat < TemperatureManager.MALLEABLE_STATE_MIN_HEAT) {
                    playerStateController.setState(PlayerStateController.MARBLE);
                    EventHandler.CallStateChangeActionEvent();
                }

                scaleChange.x = 1;
                scaleChange.y = 1;

                if (isLighterThanAir) {
                    EventHandler.CallStateChangeActionEvent();
                    playerStateController.setState(PlayerStateController.BUBBLE);
                    isLighterThanAir = false;
                    isGrowing = true;
                }
                break;
            case PlayerStateController.BUBBLE:
                if (isGrowing) {
                    scale = Mathf.Min(scale + scaleRate * Time.fixedDeltaTime, maxSize);
                    scaleChange.x = scale;
                    scaleChange.y = scale;

                    if (scale == maxSize) {
                        isGrowing = false;
                        isFloating = true;
                    }
                } 
                
                if (isFloating) {
                    int deltaT = playerStateController.bubbleStartHeat - temperatureManager.Heat;
                    // Debug.Log("Bubble Start Heat = " + playerStateController.bubbleStartHeat);
                    // Debug.Log("deltaT = " + deltaT);
   
                    rigidBody.gravityScale = -1;
                    if (deltaT > PlayerStateController.BUBBLE_FLOATING_TEMP_RANGE) {
                        isFloating = false;
                    }
                } else {
                    rigidBody.gravityScale = 1;
                }
                break;
            default:
                break;
        }

        if (player.transform.localScale != scaleChange) {
            player.transform.localScale = scaleChange;
        }

        if (temperatureManager.isHeatingUp) {
            heatingTimer += 1;
            if (temperatureManager.Heat < 100 && heatingTimer % 3 == 0) {
                temperatureManager.adjustHeat(heatRate);
                heatingTimer = 0;
            }
        } else {
            coolingTimer += 1;

            if (temperatureManager.Heat > 0 && coolingTimer % 12 == 0) {
                temperatureManager.adjustHeat(-heatRate);
                coolingTimer = 0;
            }
        }

        gameHandler.updateStatsDisplay();
    }

    // @TODO manage the various player states via a proper state machine
    public void setBubble() {
        isGrowing = true;
        isFloating = true ;
        isLighterThanAir = true;
        playerStateController.bubbleStartHeat = temperatureManager.Heat;
    }

    public void setNotBubble() {
        isGrowing = false;
        isFloating = false;
        isLighterThanAir = false;
                    playerStateController.setState(PlayerStateController.MALLEABLE);
                    EventHandler.CallStateChangeActionEvent();
    }

    public void setGrowSolid(bool growSolid) {
        isGrowing = growSolid;
        temperatureManager.isHeatingUp = growSolid;

        // confirm if we need this to be explicitly set here
        isLighterThanAir = false;
    }

    public void setHeatingUp(bool heating) {
        temperatureManager.isHeatingUp = heating;
    }

    public int getHeatLevel() {
        return temperatureManager.Heat;
    }

}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PlayerMarbleScaleController : MonoBehaviour
// {
//     private GameObject player;
//     private PlayerStateController playerStateController;
//     private Rigidbody2D rigidBody;

//     private bool isPlayerDead = false;

//     public int particleTriggerCount = 0;

//     private bool isGrowing = false;
//     private Vector3 scaleChange;
//     private Vector2 upForce;

//     float maxSize = 3f;
//     float scale = 1f;
//     float scaleRate = 1f;
//     int heatRate = 1;

//     private GameHandler gameHandler;
//     private TemperatureManager temperatureManager;
//     private bool isLighterThanAir = false;
//     public float thrust = 30f;

//     // cooling off
//     private int heatingTimer = 0;
//     public int heatingRate = 5;

//     private int coolingTimer = 0;
//     public int coolingRate = 40;

//     public float gravityScale = 1;

//     void Start() {
//         if (GameObject.FindWithTag("GameHandler") != null){
//             gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
//         }

//         player = GameObject.FindWithTag("Player");
//         playerStateController = player.GetComponent<PlayerStateController>();
//         temperatureManager = player.GetComponent<TemperatureManager>();
//         rigidBody = player.GetComponent<Rigidbody2D>();
//         scaleChange = new Vector3(1f, 1f, 1f);
//     }

//     private void Update() 
//     {
//         if (temperatureManager.Heat == 0) 
//         {
//             if(!isPlayerDead)
//             {
//                 isPlayerDead = true;
//                 EventHandler.CallPlayerDeathEvent();
//             }
//         }
        
//     }

//     void FixedUpdate() {

//         switch (playerStateController.state) {
//             case PlayerStateController.MARBLE:
//                 if (temperatureManager.Heat > TemperatureManager.MARBLE_MAX_HEAT) {
//                     playerStateController.setState(PlayerStateController.MALLEABLE);
//                     EventHandler.CallStateChangeActionEvent();
//                 }
//                 break;
//             case PlayerStateController.MALLEABLE:
//                 if (temperatureManager.Heat < TemperatureManager.MALLEABLE_STATE_MIN_HEAT) {
//                     playerStateController.setState(PlayerStateController.MARBLE);
//                     EventHandler.CallStateChangeActionEvent();
//                 }

//                 if (isLighterThanAir) {
//                     EventHandler.CallStateChangeActionEvent();
//                     playerStateController.setState(PlayerStateController.BUBBLE);
//                     playerStateController.bubbleStartHeat = temperatureManager.Heat;
//                     isLighterThanAir = false;
//                     isGrowing = true;
//                 }
//                 break;
//             case PlayerStateController.BUBBLE:
//                 if (isGrowing) {
//                     scale = Mathf.Min(scale + scaleRate * Time.fixedDeltaTime, maxSize);
//                     scaleChange.x = scale;
//                     scaleChange.y = scale;

//                     if (scale == maxSize) {
//                         isGrowing = false;
//                         isLighterThanAir = true;
//                     }
//                 }

//                 if (isLighterThanAir) {
//                     if ((playerStateController.bubbleStartHeat - temperatureManager.Heat) < PlayerStateController.BUBBLE_FLOATING_TEMP_RANGE) {
//                         rigidBody.gravityScale = -gravityScale;
//                     } else {
//                         isLighterThanAir = false;
//                         playerStateController.bubbleStartHeat = temperatureManager.Heat;
//                         rigidBody.gravityScale = 1;
//                     }
//                 } else {

//                 }

//                 if (player.transform.localScale != scaleChange) {
//                     player.transform.localScale = scaleChange;
//                 }
//                 break;
//             default:
//                 break;
//         }

//         if (temperatureManager.isHeatingUp) {
//             heatingTimer += 1;
//             if (temperatureManager.Heat < 100 && heatingTimer % heatingRate == 0) {
//                 temperatureManager.adjustHeat(heatRate);
//                 heatingTimer = 0;
//                 coolingTimer = 0;
//             }
//         } else {
//             coolingTimer += 1;

//             if (temperatureManager.Heat > 0 && coolingTimer % coolingRate == 0) {
//                 temperatureManager.adjustHeat(-heatRate);
//                 heatingTimer = 0;
//                 coolingTimer = 0;
//             }
//         }

//         gameHandler.updateStatsDisplay();
//     }

//     // @TODO manage the various player states via a proper state machine
//     public void setBubble() {
//         isGrowing = true;
//         isLighterThanAir = true;
//     }

//     public void setNotBubble() {
//         isGrowing = false;
//         isLighterThanAir = false;
//     }

//     public void setGrowSolid(bool growSolid) {
//         isGrowing = growSolid;
//         temperatureManager.isHeatingUp = growSolid;

//         // confirm if we need this to be explicitly set here
//         isLighterThanAir = false;
//     }

//     public void setHeatingUp(bool heating) {
//         temperatureManager.isHeatingUp = heating;
//     }

//     public int getHeatLevel() {
//         return temperatureManager.Heat;
//     }
// }
