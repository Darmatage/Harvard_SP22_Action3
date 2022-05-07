using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterColliderController : MonoBehaviour
{
    GameObject player;

    void OnTriggerEnter2D(Collider2D other) {
        string parentTag = other.transform.parent.gameObject.tag;

        player = GameObject.FindWithTag("Player");
        if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
			if (player.GetComponent<PlayerStateController>().state == PlayerStateController.MALLEABLE) {
				EventHandler.CallPlayerDeathEvent();
			}
		}
	}
}
