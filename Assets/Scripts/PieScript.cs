using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieScript : MonoBehaviour {

    public float speed = 10;
    private IEnumerator coroutine;
    // Use this for initialization
    void Start () {
        coroutine = AutoDestroy();
        StartCoroutine(coroutine);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    public void OnCreate(Vector2[] directions) {
        this.GetComponent<Rigidbody2D>().velocity = speed * directions[(int)(Random.value*directions.Length)];
    }
}
