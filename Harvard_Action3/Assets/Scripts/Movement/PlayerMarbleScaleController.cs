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

    void FixedUpdate() {
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

        if (temperatureManager.Heat == 0) 
        {
            if(!isPlayerDead)
            {
                isPlayerDead = true;
                EventHandler.CallPlayerDeathEvent();
            }
        }

        switch (playerStateController.state) {
            case PlayerStateController.MARBLE:
                rigidBody.gravityScale = 1;
                isFloating = false;
                if (temperatureManager.Heat > TemperatureManager.MARBLE_MAX_HEAT) {
                    playerStateController.setState(PlayerStateController.MALLEABLE);
                    EventHandler.CallStateChangeActionEvent();
                }
                break;
            case PlayerStateController.MALLEABLE:
                rigidBody.gravityScale = 1;
                isFloating = false;
                if (temperatureManager.Heat < TemperatureManager.MALLEABLE_STATE_MIN_HEAT) {
                    playerStateController.setState(PlayerStateController.MARBLE);
                    EventHandler.CallStateChangeActionEvent();
                }

                scale = 1;
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
                    temperatureManager.isHeatingUp = false;
                    floatingTimer++;
                    int deltaT = playerStateController.bubbleStartHeat - temperatureManager.Heat;
   
                    rigidBody.gravityScale = -1;
                    if (floatingTimer % 150 == 0) {
                        isFloating = false;
                        floatingTimer = 0;
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


        gameHandler.updateStatsDisplay();
    }

    // @TODO manage the various player states via a proper state machine
    public void setBubble() {
        isGrowing = true;
        isLighterThanAir = true;
        playerStateController.bubbleStartHeat = temperatureManager.Heat;
        particleTriggerCount = 0;
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
