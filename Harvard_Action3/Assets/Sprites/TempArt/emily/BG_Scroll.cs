using System.Collections;
using UnityEngine;

public class BG_Scroll : MonoBehaviour {

	public float BGspeed = 0.5f;
	public Renderer BGrend;

	void Start(){
		BGrend = GetComponent<Renderer>();
		//Change the GameObject's Material Color to red
		//BGrend.material.color = Color.red;
	}

	void Update () {
		Vector2 hOffset	= new Vector2 (Time.time * BGspeed, 0);
		BGrend.material.mainTextureOffset = hOffset;
	}
}

//https://www.youtube.com/watch?v=32EIYs6Z18Q
