using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class RingofHeat : MonoBehaviour{

      public GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  GetComponent<Collider2D>().enabled = false;
                  GetComponent<AudioSource>().Play();

                        //playerPowerupVFX.powerup();
                  }


            }
      }
