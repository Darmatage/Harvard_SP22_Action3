using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrucibleController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<PlayerMarbleScaleController>().setGrowSolid(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<PlayerMarbleScaleController>().setGrowSolid(false);
        }
    }
}
