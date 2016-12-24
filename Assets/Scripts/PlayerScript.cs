using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	PieThrower pt;
    public int hitPoint=10;

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

    void OnTriggerEnter2D(Collider2D c)
    {
        // 弾の削除
        Destroy(c.gameObject);

        hitPoint--;
        if (hitPoint<=0)
        {
            // プレイヤーを削除
            Destroy(this.gameObject);
        }
    }
}
