using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowpipeController : MonoBehaviour
{
    private AudioSource blowpipeSound;
    private GameObject player;

    void Start() {
        blowpipeSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        string parentTag = other.transform.parent.gameObject.tag;
        if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
            blowpipeSound.Play();

            player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerMarbleScaleController>().setBubble();
            player.gameObject.GetComponent<PlayerStateController>().setState(PlayerStateController.BUBBLE);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        string parentTag = other.transform.parent.gameObject.tag;
        if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
            player = GameObject.FindWithTag("Player");
            player.gameObject.GetComponent<PlayerMarbleScaleController>().setNotBubble();
        }
    }
}
