using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AnimSound : MonoBehaviour{

      //public playerVFX playerPowerupVFX;

      void Start(){
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  GetComponent<AudioSource>().Play();

                        //playerPowerupVFX.powerup();
                  }


            }
      }
