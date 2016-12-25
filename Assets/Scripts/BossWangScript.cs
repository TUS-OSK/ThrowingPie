using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BossWangScript : MonoBehaviour
{

    Transform tf;
    PieThrower pt;
    GameObject Pie;
    public float shotWaitTime;
    private IEnumerator coroutine;
    public int hitPoint;

    // Use this for initialization
    void Start()
    {
        tf = this.GetComponent<Transform>();
        pt = this.GetComponent<PieThrower>();

        coroutine = ThrowPie(shotWaitTime);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        pt.Move(transform.up * -1);

    }

    IEnumerator ThrowPie(float waittime)
    {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            pt.Shot(tf, new Vector2(0, -1));
            // waittime待つ
            yield return new WaitForSeconds(waittime);
        }
    }

    void OnMouseDown()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("kill");
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag != "PlayerPie") return;
        hitPoint--;
        // 弾の削除
        Destroy(c.gameObject);
        if (hitPoint <= 0)
        {
            // プレイヤーを削除
            GameObject.Find("GameController").GetComponent<GameControllerScript>().toGameClear();
            StartCoroutine(coroutine);
        }
    }
}
