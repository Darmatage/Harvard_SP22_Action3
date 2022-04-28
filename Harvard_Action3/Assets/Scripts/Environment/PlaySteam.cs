using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlaySteam : MonoBehaviour{

  public ParticleSystem collisionParticleSystem;

  private void OnTriggerEnter2D (Collider2D other){
             if (other.gameObject.tag == "Player"){
               var em = collisionParticleSystem.emission;
    //           var dur = collisionParticleSystem.duration;

               em.enabled = true;
               collisionParticleSystem.Play();
      //             Steam.GetComponent<ParticleSystem> ()emission.enabled = true;
      //             StartCoroutine (stopSteam ());
                }
      //
      //
      //     }
      // IEnumerator stopSteam()
      // {
      //   yield return new WaitForSeconds (.4f);
      //   Steam.GetComponent<ParticleSystem> ().emission.enabled = false;
       }
    }
