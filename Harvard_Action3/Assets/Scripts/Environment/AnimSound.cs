using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AnimSound : MonoBehaviour {
      public void OnTriggerEnter2D (Collider2D other) {
            if (other.tag == "SolidContainer") {
                  GetComponent<AudioSource>().Play();
            }
      }
}