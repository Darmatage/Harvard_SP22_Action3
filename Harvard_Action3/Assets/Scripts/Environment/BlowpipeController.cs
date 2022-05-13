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
        player = GameObject.FindWithTag("Player");

        if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
            if (player.GetComponent<PlayerMarbleScaleController>().particleTriggerCount == 0) {
                blowpipeSound.Play();

                player = GameObject.FindWithTag("Player");
                player.GetComponent<PlayerMarbleScaleController>().setBubble();
            }
            player.GetComponent<PlayerMarbleScaleController>().particleTriggerCount++;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        string parentTag = other.transform.parent.gameObject.tag;

        player = GameObject.FindWithTag("Player");
        if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
            player.GetComponent<PlayerMarbleScaleController>().setIsGrowing(false);
            player.GetComponent<PlayerMarbleScaleController>().particleTriggerCount--;
        }
    }
}
