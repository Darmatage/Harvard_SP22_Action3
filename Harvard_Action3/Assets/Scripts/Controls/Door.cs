using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// public class Door : MonoBehaviour{
//
//       public string NextLevel = "MainMenu";
//
//       public void OnTriggerEnter2D(Collider2D other){
//             if (other.gameObject.tag == "Player"){
//                   SceneManager.LoadScene (NextLevel);
//             }
//       }
//
// }

public class Door : MonoBehaviour{

      public string NextLevel = "MainMenu";
      GameObject player;

      public void OnTriggerEnter2D(Collider2D other){
            string parentTag = other.transform.parent.gameObject.tag;
            player = GameObject.FindWithTag("Player");
            if (other.tag == "Player" || other.tag == "SolidContainer" || parentTag == "ParticleContainer") {
                  SceneManager.LoadScene (NextLevel);
            }
      }

}
