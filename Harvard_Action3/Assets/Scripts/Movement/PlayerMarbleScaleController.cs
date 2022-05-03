using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarbleScaleController : MonoBehaviour
{
    private GameObject player;
    private PlayerStateController playerStateController;
    private Rigidbody2D rigidBody;

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
    public float thrust = 30f;

    // cooling off
    private int heatingTimer = 0;
    private int coolingTimer = 0;

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

                if (isGrowing) {
                    scale = Mathf.Min(scale + scaleRate * Time.fixedDeltaTime, maxSize);
                    scaleChange.x = scale;
                    scaleChange.y = scale;

                    if (scale == maxSize) {
                        isGrowing = false;
                        playerStateController.setState(PlayerStateController.BUBBLE);
                        playerStateController.bubbleStartHeat = temperatureManager.Heat;
                    }
                } else if (isShrinking) {
                    scale = Mathf.Max(scale - scaleRate * Time.fixedDeltaTime, minSize);
                    scaleChange.x = scale;
                    scaleChange.y = scale;

                    if (scale == minSize) {
                        isShrinking = false;
                        isLighterThanAir = false;
                        rigidBody.gravityScale = 1;
                    }
                }

                if (player.transform.localScale != scaleChange) {
                    player.transform.localScale = scaleChange;
                }
                break;
            case PlayerStateController.BUBBLE:
                if ((playerStateController.bubbleStartHeat - temperatureManager.Heat) < PlayerStateController.BUBBLE_FLOATING_TEMP_RANGE) {
                    rigidBody.gravityScale = -1;
                } else {
                    rigidBody.gravityScale = 1;
                }
                break;
            default:
                break;
        }

        if (temperatureManager.isHeatingUp) {
            heatingTimer += 1;
            if (temperatureManager.Heat < 100 && heatingTimer % 3 == 0) {
                temperatureManager.adjustHeat(heatRate);
                heatingTimer = 0;
            }
        } else {
            coolingTimer += 1;

            if (temperatureManager.Heat > 0 && coolingTimer % 6 == 0) {
                temperatureManager.adjustHeat(-heatRate);
                coolingTimer = 0;
            }
        }

        gameHandler.updateStatsDisplay();
    }

    // @TODO manage the various player states via a proper state machine
    public void setBubble() {
        isGrowing = true;
        isShrinking = false;
        isLighterThanAir = true;
    }

    public void setNotBubble() {
        isGrowing = false;
        isShrinking = true;
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
