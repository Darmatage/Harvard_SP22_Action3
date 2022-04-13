using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarbleScaleController : MonoBehaviour
{
    private GameObject player;
    private Sprite playerSprite;
    private Vector3 scaleChange;

    float scaleRate = 0.5f;
    float scale = 1f;

    bool isShrinking;

    void Start() {
        player = GameObject.FindWithTag("Player");
        playerSprite = player.GetComponent<Sprite>();
        scaleChange = new Vector3(1f, 1f, 1f);
        isShrinking = false;
    }
        
    void Update() {
        if (isShrinking) {
            scale = Mathf.Max(scale - scaleRate * Time.deltaTime, 1.0f);
            scaleChange.x = scale;
            scaleChange.y = scale;
        }

        player.transform.localScale = scaleChange;
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "BlowPipe") {
            scale = Mathf.Min(scale + scaleRate * Time.deltaTime, 5.0f);

            scaleChange.x = scale;
            scaleChange.y = scale;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        isShrinking = false;
    }

    void OnTriggerExit2D(Collider2D other) {
        isShrinking = true;
    }
}
