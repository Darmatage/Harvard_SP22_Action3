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

    void Start() {
        player = GameObject.FindWithTag("Player");
        playerSprite = player.GetComponent<Sprite>();
        scaleChange = new Vector3(1f, 1f, 1f);
    }
        
    void Update() {
        player.transform.localScale = scaleChange;
    }

    void OnTriggerStay2D(Collider2D other) {
        Debug.Log("Player OnCollisionStay2D: " + other.gameObject.tag);

        if (other.gameObject.tag == "BlowPipe") {
            scale = Mathf.Min(scale + scaleRate * Time.deltaTime, 5.0f);
            Debug.Log("Scale = " + scale);

            scaleChange.x = scale;
            scaleChange.y = scale;
        }
    }
}
