using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangMaker : MonoBehaviour {

    public GameObject wang;
    Transform tf;
    private float timeleft;

    // Use this for initialization
    void Start () {
        tf = this.GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
            if (timeleft <= 0.0)
            {
                timeleft = 0.5f;
                tf.position = new Vector3(tf.position.x + (Random.value - 0.5f) * 2, tf.position.y, tf.position.z);
                // Instantiate(wang, tf);
            }
        }
   
}