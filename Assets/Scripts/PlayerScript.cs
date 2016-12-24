using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	PieThrower pt;

	void Start () {
		this.pt = this.GetComponent<PieThrower>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.M))
		{
			if (Time.frameCount % 10 == 0)
			{
		  		pt.Shot(this.GetComponent<Transform>(), new Vector2(0,1));	
			}
		}
	}
}
