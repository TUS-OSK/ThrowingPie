using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	PieThrower pt;
    public int hitPoint=10;
	public int shootFrame = 4;
    private IEnumerator coroutine;
    private Transform tf;

    void Start () {
		this.pt = this.GetComponent<PieThrower>();
        this.tf = this.GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.M))
		{
			if (Time.frameCount % shootFrame == 0)
			{
		  		pt.Shot(this.GetComponent<Transform>());	
			}
		}

        if (tf.position.x<-10) {
            tf.position = new Vector3(-10,tf.position.y,tf.position.z);
        }
        if (tf.position.x > 10)
        {
            tf.position = new Vector3(10, tf.position.y, tf.position.z);
        }
        if (tf.position.y > 3)
        {
            tf.position = new Vector3(tf.position.x, 3, tf.position.z);
        }
        if (tf.position.y < -6)
        {
            tf.position = new Vector3(tf.position.x, -6, tf.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
		if (c.tag != "WangPie") return;
        // 弾の削除
        Destroy(c.gameObject);

        hitPoint--;
        if (hitPoint<=0)
        {
            // プレイヤーを削除
            GameObject.Find("GameController").GetComponent<GameControllerScript>().toGameover();
            Destroy(this.gameObject);
        }
    }
}
