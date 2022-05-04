using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShearsController : MonoBehaviour {
    GameObject player;

    void OnTriggerEnter2D(Collider2D other) {
        string parentTag = other.transform.parent.gameObject.tag;

        player = GameObject.FindWithTag("Player");
        if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
            switch (player.GetComponent<PlayerStateController>().state) {
                case PlayerStateController.MARBLE:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                case PlayerStateController.BUBBLE:
                    player.GetComponent<PlayerMarbleScaleController>().setNotBubble();
                    break;
                default:
                    break;
			}
		}
	}
}
