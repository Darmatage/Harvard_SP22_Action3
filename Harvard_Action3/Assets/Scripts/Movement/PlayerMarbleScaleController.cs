using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarbleScaleController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rigidBody;

    private bool isGrowing = false;
    private bool isShrinking = false;
    private Vector3 scaleChange;
    private Vector2 upForce;

    float minSize = 1f;
    float maxSize = 3f;
    float scale = 1f;
    float scaleRate = 1f;

    private bool isFloating = false;
    public float thrust = 7f;

    void Start() {
        player = GameObject.FindWithTag("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        scaleChange = new Vector3(1f, 1f, 1f);

        upForce = new Vector2(0f, thrust);
    }

    void Update() {
        if (isGrowing) {
            scale = Mathf.Min(scale + scaleRate * Time.deltaTime, maxSize);
            scaleChange.x = scale;
            scaleChange.y = scale;

            Debug.Log("Scale grow = " + scale);
            if (scale == maxSize) {
                isGrowing = false;
                isFloating = true;
            }
        } else if (isShrinking) {
            scale = Mathf.Max(scale - scaleRate * Time.deltaTime, minSize);
            scaleChange.x = scale;
            scaleChange.y = scale;

            if (scale == minSize) {
                isShrinking = false;
                isFloating = false;
            }
        }

        if (isFloating) {
            rigidBody.AddForce(upForce, ForceMode2D.Force);
        }

        if (player.transform.localScale != scaleChange) {
            player.transform.localScale = scaleChange;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        isGrowing = true;
        isShrinking = false;
    }

    void OnTriggerExit2D(Collider2D other) {
        isGrowing = false;
        isShrinking = true;
    }
}
