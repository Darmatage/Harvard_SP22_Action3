using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AnimSound : MonoBehaviour {
      public void OnTriggerEnter2D (Collider2D other) {
            string parentTag = other.transform.parent.gameObject.tag;
            if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
                  GetComponent<AudioSource>().Play();
            }
      }
}