using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatRingController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        string parentTag = other.transform.parent.gameObject.tag;
        // Debug.Log("Enter " + other.tag + ", " + parentTag);
        if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
            GameObject.FindWithTag("Player").GetComponent<TemperatureManager>().isHeatingUp = true;
        }
    }

    // void OnTriggerExit2D(Collider2D other) {
    //     Debug.Log("Exit " + other.transform.parent.gameObject.tag);
    //     if (other.tag == "SolidContainer" || other.tag == "ParticleContainer") {
    //         other.gameObject.GetComponent<PlayerMarbleScaleController>().setHeatingUp(false);
    //     }
    // }
}
