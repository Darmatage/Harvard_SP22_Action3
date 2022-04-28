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
        if (other.tag == "Player") {
            blowpipeSound.Play();

            other.gameObject.GetComponent<PlayerMarbleScaleController>().setBubble();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<PlayerMarbleScaleController>().setNotBubble();
        }
    }
}
