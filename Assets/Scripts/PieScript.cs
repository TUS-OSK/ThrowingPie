using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieScript : MonoBehaviour {

    public int speed = 10;
    private IEnumerator coroutine;
    // Use this for initialization
    void Start () {
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {
        coroutine = AutoDestroy();
        StartCoroutine(coroutine);
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
