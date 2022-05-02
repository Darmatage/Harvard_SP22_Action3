using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarbleScaleController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rigidBody;

    private bool isHeatingUp = false;
    private bool isGrowing = false;
    private bool isShrinking = false;
    private Vector3 scaleChange;
    private Vector2 upForce;

    float minSize = 1f;
    float maxSize = 3f;
    float scale = 1f;
    float scaleRate = 1f;
    int heatRate = 1;

    public GameHandler gameHandler;
    public TemperatureManager temperatureManager;
    private bool isLighterThanAir = false;
    private bool isFloating = false;
    public float thrust = 30f;

    // cooling off
    private int coolingTimer = 0;

    void Start() {
        if (GameObject.FindWithTag("GameHandler") != null){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }

        player = GameObject.FindWithTag("Player");
        temperatureManager = player.GetComponent<TemperatureManager>();
        rigidBody = player.GetComponent<Rigidbody2D>();
        scaleChange = new Vector3(1f, 1f, 1f);
    }

    void FixedUpdate() {
        if (isGrowing) {
            scale = Mathf.Min(scale + scaleRate * Time.fixedDeltaTime, maxSize);
            scaleChange.x = scale;
            scaleChange.y = scale;

            if (scale == maxSize) {
                isGrowing = false;

                if (isLighterThanAir) {
                    isFloating = true;
                }
            }
        } else if (isShrinking) {
            scale = Mathf.Max(scale - scaleRate * Time.fixedDeltaTime, minSize);
            scaleChange.x = scale;
            scaleChange.y = scale;

            if (scale == minSize) {
                isShrinking = false;
                isFloating = false;
                isLighterThanAir = false;
            }
        }

        if (isHeatingUp) {
            temperatureManager.adjustHeat(heatRate);
        }
        gameHandler.updateStatsDisplay();

        if (player.transform.localScale != scaleChange) {
            player.transform.localScale = scaleChange;
        }

        if (isFloating) {
            Debug.Log("Add Force " + upForce);
            rigidBody.AddForce(new Vector2(0f, thrust), ForceMode2D.Force);
        }

        coolingTimer += 1;
        if (coolingTimer % 6 == 0) {
            // cool off
            if (!isHeatingUp && temperatureManager.Heat > 0) {
                temperatureManager.adjustHeat(-heatRate);
            }

            coolingTimer = 0;
        }
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
        isHeatingUp = growSolid;

        // confirm if we need this to be explicitly set here
        isLighterThanAir = false;
    }

    public void setHeatingUp(bool heating) {
        isHeatingUp = heating;
    }

    public int getHeatLevel() {
        return temperatureManager.Heat;
    }

}
