using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	PieThrower pt;
    public int hitPoint=10;
	public int shootFrame = 4;
    private IEnumerator coroutine;

    void Start () {
		this.pt = this.GetComponent<PieThrower>();
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
