using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatRingController : MonoBehaviour
{
    GameObject player;

    void OnTriggerEnter2D(Collider2D other) {
        string parentTag = other.transform.parent.gameObject.tag;

        player = GameObject.FindWithTag("Player");
        if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
            if (player.GetComponent<PlayerMarbleScaleController>().particleTriggerCount == 0) {
                player.GetComponent<TemperatureManager>().isHeatingUp = true;
            }
            // player.GetComponent<PlayerMarbleScaleController>().particleTriggerCount++;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        string parentTag = other.transform.parent.gameObject.tag;
        if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
            // player.GetComponent<PlayerMarbleScaleController>().particleTriggerCount--;
            if (player.GetComponent<PlayerMarbleScaleController>().particleTriggerCount == 0) {
                player.GetComponent<TemperatureManager>().isHeatingUp = false;
            }
        }
    }
}
