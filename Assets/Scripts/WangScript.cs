using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WangScript : MonoBehaviour {

    Transform tf;
	// Use this for initialization
	void Start () {
        tf = this.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        tf.position = new Vector3(tf.position.x + Random.value - 0.5f, tf.position.y + Random.value - 0.5f, tf.position.z);
	}
    
    void OnMouseDown()
    {
        Debug.Log("kill");
        Destroy(this.gameObject);
    }
}
