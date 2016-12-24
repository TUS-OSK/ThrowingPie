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
        Transform tf = this.GetComponent<Transform>();
        tf.position = new Vector3(tf.position.x + 1, tf.position.y, tf.position.z);
	}
}
