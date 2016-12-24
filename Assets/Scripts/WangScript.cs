using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WangScript : MonoBehaviour {

    Transform tf;
    PieThrower pt;
    GameObject Pie;
    private IEnumerator coroutine;
    // Use this for initialization
    void Start()
    {
        tf = this.GetComponent<Transform>();
        pt = this.GetComponent<PieThrower>();

        coroutine = ThrowPie(2.0f);
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
            pt.Shot(tf);
            // 0.05秒待つ
            yield return new WaitForSeconds(0.5f);
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
