using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WangScript : MonoBehaviour {

    Transform tf;
    PieThrower pt;
	// Use this for initialization
	void Start () {
        tf = this.GetComponent<Transform>();
        pt = this.GetComponent<PieThrower>();
    }
	
	// Update is called once per frame
	void Update () {
        pt.Move(transform.up * -1);
    }
    
    void OnMouseDown()
    {
        Debug.Log("kill");
        Destroy(this.gameObject);
    }
}
