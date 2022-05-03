using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

      public GameHandler gameHandler;

      void Start() {
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
      }

      public void OnTriggerEnter2D (Collider2D other) {
            string parentTag = other.transform.parent.gameObject.tag;
            if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
                  GetComponent<Collider2D>().enabled = false;
                  GetComponent<AudioSource>().Play();
                  StartCoroutine(DestroyThis());

                  gameHandler.playerGetTokens(1);
            }
      }
      
      IEnumerator DestroyThis() {
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
      }
}
