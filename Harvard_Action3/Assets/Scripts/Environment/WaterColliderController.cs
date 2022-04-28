using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WaterColliderController : MonoBehaviour
{
	public void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
            int heat = other.gameObject.GetComponent<PlayerMarbleScaleController>().getHeatLevel();

			if (heat > 150) {
				Debug.Log("SHATTER");
				// Sprite s = player.GetComponent<Sprite>();
				// Destroy(s);
			}
		}
	}
}
