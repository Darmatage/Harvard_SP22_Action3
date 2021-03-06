using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Control;

public class CrucibleController : MonoBehaviour
{
    [SerializeField] bool doubleSize = false;
    GameObject player;
    void OnTriggerEnter2D(Collider2D other) 
    {
        string parentTag = other.transform.parent.gameObject.tag;
        player = GameObject.FindWithTag(Tags.PLAYER_TAG);

        if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") 
        {
            if (player.GetComponent<PlayerMarbleScaleController>().particleTriggerCount == 0)
            {
                player.GetComponent<PlayerMarbleScaleController>().setGrowSolid(true);
            }
            player.GetComponent<PlayerMarbleScaleController>().particleTriggerCount++;
        }

        if(doubleSize)
        {
            EventHandler.CallDoubleSizeEvent();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        string parentTag = other.transform.parent.gameObject.tag;
        if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
            player.GetComponent<PlayerMarbleScaleController>().particleTriggerCount--;
            if (player.GetComponent<PlayerMarbleScaleController>().particleTriggerCount == 0) {
                player.GetComponent<PlayerMarbleScaleController>().setGrowSolid(false);
            }
        }
    }
}
