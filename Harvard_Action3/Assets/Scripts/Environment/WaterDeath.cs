using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WaterDeath : MonoBehaviour {

       public GameHandler gameHandlerObj;
       public int damage = 50;
       //public Transform backToStart; //uncomment this line for "auto-death," to zap the Player back to start

       void Start(){
            if (GameObject.FindWithTag("GameHandler") != null){
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            }
       }

       public void OnCollisionEnter2D(Collision2D other) {
              if (other.gameObject.tag == "Player") {
      //          check if playerHealth >= 101;

                     gameHandlerObj.playerGetHit(damage);
                     //other.transform.position = new Vector3(backToStart.position.x, backToStart.position.y, backToStart.position.z);
              }
       }
}
