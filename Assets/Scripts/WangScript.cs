using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WangScript : MonoBehaviour {

    Transform tf;
    PieThrower pt;
    GameObject Pie;
    float shotWaitTime = 2.0f;
    private IEnumerator coroutine;
    // Use this for initialization
    void Start()
    {
        tf = this.GetComponent<Transform>();
        pt = this.GetComponent<PieThrower>();

        coroutine = ThrowPie(shotWaitTime);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update () {
        pt.Move(transform.up * -1);

    }

    IEnumerator ThrowPie(float waittime) {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            pt.Shot(tf,new Vector2(0,-1));
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
}
