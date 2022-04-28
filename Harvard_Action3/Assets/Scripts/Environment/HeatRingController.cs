using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatRingController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<PlayerMarbleScaleController>().setHeatingUp(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<PlayerMarbleScaleController>().setHeatingUp(false);
        }
    }
}
