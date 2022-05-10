using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMarbleScaleController : MonoBehaviour
{
    private GameObject player;
    private PlayerStateController playerStateController;
    private Rigidbody2D rigidBody;

    private bool isPlayerDead = false;

    public int particleTriggerCount = 0;

    private bool isGrowing = false;
    private Vector3 scaleChange;
    private Vector2 upForce;

    float maxSize = 3f;
    float scale = 1f;
    float scaleRate = 1f;
    int heatRate = 1;

    private GameHandler gameHandler;
    private TemperatureManager temperatureManager;
    private bool isLighterThanAir = false;
    public float thrust = 30f;

    // cooling off
    private int heatingTimer = 0;
    public int heatingRate = 5;

    private int coolingTimer = 0;
    public int coolingRate = 40;

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

    private void Update() 
    {
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

                if (isLighterThanAir) {
                    EventHandler.CallStateChangeActionEvent();
                    playerStateController.setState(PlayerStateController.BUBBLE);
                    playerStateController.bubbleStartHeat = temperatureManager.Heat;
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
                    }
                } else {
                    Debug.Log("Bubble Start Heat = " + playerStateController.bubbleStartHeat);
                    Debug.Log("deltaT = " + (playerStateController.bubbleStartHeat - temperatureManager.Heat));
                    if ((playerStateController.bubbleStartHeat - temperatureManager.Heat) < PlayerStateController.BUBBLE_FLOATING_TEMP_RANGE) {
                        rigidBody.gravityScale = -1;
                    } else {
                        rigidBody.gravityScale = 1;
                    }
                }
            // case PlayerStateController.MARBLE:
            //     if (temperatureManager.Heat > TemperatureManager.MARBLE_MAX_HEAT) {
            //         playerStateController.setState(PlayerStateController.MALLEABLE);
            //         EventHandler.CallStateChangeActionEvent();
            //     }
            //     break;
            // case PlayerStateController.MALLEABLE:
            //     if (temperatureManager.Heat < TemperatureManager.MALLEABLE_STATE_MIN_HEAT) {
            //         playerStateController.setState(PlayerStateController.MARBLE);
            //         EventHandler.CallStateChangeActionEvent();
            //     }

            //     if (isLighterThanAir) {
            //         EventHandler.CallStateChangeActionEvent();
            //         playerStateController.setState(PlayerStateController.BUBBLE);
            //         playerStateController.bubbleStartHeat = temperatureManager.Heat;
            //         isLighterThanAir = false;
            //         isGrowing = true;
            //     }
            //     break;
            // case PlayerStateController.BUBBLE:
            //     if (scale < maxSize) {
            //         scale = Mathf.Min(scale + scaleRate * Time.fixedDeltaTime, maxSize);
            //         scaleChange.x = scale;
            //         scaleChange.y = scale;
            //     } else {
            //         playerStateController.bubbleStartHeat = temperatureManager.Heat;
            //         isGrowing = false;
            //         playerStateController.setState(PlayerStateController.BUBBLE_FLOATING);
            //     }

            //     if (player.transform.localScale != scaleChange) {
            //         player.transform.localScale = scaleChange;
            //     }

            //     break;
            // case PlayerStateController.BUBBLE_FLOATING:
            //         int deltaT = playerStateController.bubbleStartHeat - temperatureManager.Heat;
            //         Debug.Log("BubbleFloating: deltaT = " + deltaT);

            //         if (deltaT < PlayerStateController.BUBBLE_FLOATING_TEMP_RANGE) {
            //             rigidBody.gravityScale = -1;
            //         } else {
            //             rigidBody.gravityScale = 1;
            //             // playerStateController.setState(PlayerStateController.BUBBLE);
            //         }
            //     break;
            default:
                break;
        }

        if (temperatureManager.isHeatingUp) {
            heatingTimer += 1;
            if (temperatureManager.Heat < 100 && heatingTimer % heatingRate == 0) {
                temperatureManager.adjustHeat(heatRate);
                heatingTimer = 0;
                coolingTimer = 0;
            }
        } else {
            coolingTimer += 1;

            if (temperatureManager.Heat > 0 && coolingTimer % coolingRate == 0) {
                temperatureManager.adjustHeat(-heatRate);
                heatingTimer = 0;
                coolingTimer = 0;
            }
        }

        gameHandler.updateStatsDisplay();
    }

    // @TODO manage the various player states via a proper state machine
    public void setBubble() {
        isGrowing = true;
        isLighterThanAir = true;
    }

    public void setNotBubble() {
        isGrowing = false;
        isLighterThanAir = false;
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
