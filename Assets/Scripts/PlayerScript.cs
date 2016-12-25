﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	PieThrower pt;
    public int hitPoint=10;
    private IEnumerator coroutine;

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
		if (c.tag != "WangPie") return;
        // 弾の削除
        Destroy(c.gameObject);

        hitPoint--;
        if (hitPoint<=0)
        {
            // プレイヤーを削除
            coroutine = GoGameover();
            StartCoroutine(coroutine);
            Destroy(this.gameObject);
        }
    }
    IEnumerator GoGameover()
    {
        yield return new WaitForSeconds(5f);
        GameObject.Find("GameController").GetComponent<GameControllerScript>().toGameover();
    }
}
