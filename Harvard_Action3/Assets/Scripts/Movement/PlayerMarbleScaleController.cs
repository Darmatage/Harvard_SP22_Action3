using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarbleScaleController : MonoBehaviour
{
    private GameObject player;
    private GameObject blowpipe;
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
    public float thrust = 7f;

    // cooling off
    private int coolingTimer = 0;


    void Start() {
        if (GameObject.FindWithTag("GameHandler") != null){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }

        player = GameObject.FindWithTag("Player");
        blowpipe = GameObject.FindWithTag("BlowPipe");
        temperatureManager = player.GetComponent<TemperatureManager>();
        rigidBody = GetComponent<Rigidbody2D>();
        scaleChange = new Vector3(1f, 1f, 1f);

        upForce = new Vector2(0f, thrust);
    }

    void Update() {
        if (isGrowing) {
            scale = Mathf.Min(scale + scaleRate * Time.deltaTime, maxSize);
            scaleChange.x = scale;
            scaleChange.y = scale;

            if (scale == maxSize) {
                isGrowing = false;

                if (isLighterThanAir) {
                    isFloating = true;
                }
            }
        } else if (isShrinking) {
            scale = Mathf.Max(scale - scaleRate * Time.deltaTime, minSize);
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

        if (isFloating) {
            rigidBody.AddForce(upForce, ForceMode2D.Force);
        }

        if (player.transform.localScale != scaleChange) {
            player.transform.localScale = scaleChange;
        }
    }

    void FixedUpdate() {
        coolingTimer += 1;
        if (coolingTimer % 6 == 0) {
            // cool off
            if (!isHeatingUp && temperatureManager.Heat > 0) {
                temperatureManager.adjustHeat(-heatRate);
            }

            coolingTimer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
      if (other.tag == "BlowPipe") {
        AudioSource BlowPipeSound = blowpipe.GetComponent<AudioSource>();
        BlowPipeSound.Play();
        isGrowing = true;
        isLighterThanAir = true;
        isShrinking = false;
      } else if (other.tag == "Crucible") {
        isGrowing = true;
        isHeatingUp = true;
        isLighterThanAir = false;
      } else if (other.tag == "HeatRing") {
        isHeatingUp = true;
      }

    }

    void OnTriggerExit2D(Collider2D other) {
      if (other.tag == "BlowPipe") {
        isGrowing = false;
        isShrinking = true;
      } else if (other.tag == "Crucible") {
          isGrowing = false;
          isHeatingUp = false;
      } else if (other.tag == "HeatRing") {
        isHeatingUp = false;
      }
    }
}
