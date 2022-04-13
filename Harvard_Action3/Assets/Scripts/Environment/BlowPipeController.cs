using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowPipeController : MonoBehaviour
{
    float scaleRate = 0.5f;
    float scale = 1f;

    void OnTriggerStay2D(Collider2D other) {
        // Debug.Log("OnCollisionStay2D");

        // if (other.gameObject.tag == "Player") {
        //     scale = Mathf.Min(scale + scaleRate * Time.deltaTime, 5.0f);
        //     Debug.Log("Scale = " + scale);
        // }
    }
}
