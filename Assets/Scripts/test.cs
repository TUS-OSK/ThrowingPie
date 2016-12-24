using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	float x;
	float y; 

	// Use this for initialization
	void Start () {
		x = 0;
		y = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Transform target = this.GetComponent<Transform>();
		x += 0.1f;
		y += 0.1f;
		target.position = new Vector3(x,y,0);
	}
}
