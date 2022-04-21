using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DamageInstant : MonoBehaviour {

       public GameHandler gameHandlerObj;
       public int damage = 1;
       //public Transform backToStart; //uncomment this line for "auto-death," to zap the Player back to start

       void Start(){
            if (GameObject.FindWithTag("GameHandler") != null){
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            }
       }

       public void OnCollisionEnter2D(Collision2D other) {
              if (other.gameObject.tag == "Player") {
                     gameHandlerObj.playerGetHit(damage);
                     //other.transform.position = new Vector3(backToStart.position.x, backToStart.position.y, backToStart.position.z);
              }
       }
}
