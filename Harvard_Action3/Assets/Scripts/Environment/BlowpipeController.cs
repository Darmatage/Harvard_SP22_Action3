using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowpipeController : MonoBehaviour
{
    private AudioSource blowpipeSound;

    void Start() {
        blowpipeSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "SolidContainer") {
            blowpipeSound.Play();

            other.gameObject.GetComponent<PlayerMarbleScaleController>().setBubble();
            other.gameObject.GetComponent<PlayerStateController>().setState(PlayerStateController.BUBBLE);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "SolidContainer") {
            other.gameObject.GetComponent<PlayerMarbleScaleController>().setNotBubble();
        }
    }
}
