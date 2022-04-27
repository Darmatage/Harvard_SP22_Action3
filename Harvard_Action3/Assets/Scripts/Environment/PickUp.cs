using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

      public GameHandler gameHandler;
      // //public playerVFX playerPowerupVFX;
      // public bool isFritPickUp = true;
      //
      //
      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  GetComponent<Collider2D>().enabled = false;
                  GetComponent<AudioSource>().Play();
                  StartCoroutine(DestroyThis());
      //
      //             if (isFritPickup == true) {
      //                   gameHandler.playerGetTokens(gotTokens * -1);
      //                   //playerPowerupVFX.powerup();
                  }
      //
      //             // if (isSpeedBoostPickUp == true) {
      //             //       other.gameObject.GetComponent<PlayerMove>().speedBoost(speedBoost, speedTime);
      //             //       //playerPowerupVFX.powerup();
      //             // }
      //       }
      }
      //
      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
      }

}
