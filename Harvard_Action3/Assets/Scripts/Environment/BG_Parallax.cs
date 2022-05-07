using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BG_Parallax : MonoBehaviour {

      private GameObject camera;
      private float length, startposX;
      public float parallaxEffect;

    
      void Start(){
            camera = GameObject.FindWithTag("PlayerCamera");
            startposX = transform.position.x;
            length = GetComponent<TilemapRenderer>().bounds.size.x;
            // length = GetComponent<SpriteRenderer>().bounds.size.x;
      }

      void FixedUpdate(){
            float temp = (camera.transform.position.x * (1 - parallaxEffect));
            float distX = (camera.transform.position.x * parallaxEffect);
            transform.position = new Vector3(startposX + distX, transform.position.y, transform.position.z);

            if (temp > startposX + length){
                  startposX += length;
            }
            else if (temp < startposX - length){
                  startposX -= length;
            }
      }

}
