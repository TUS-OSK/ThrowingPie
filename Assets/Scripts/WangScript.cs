using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WangScript : MonoBehaviour {

    Transform tf;
    PieThrower pt;
    Rigidbody2D rb;
    GameObject Pie;
    public float shotWaitTime;
    private IEnumerator coroutine;
    public int hitPoint;
    private int count;
    float speed = 10f;

    // Use this for initialization
    void Start()
    {
        tf = this.GetComponent<Transform>();
        pt = this.GetComponent<PieThrower>();
        this.rb = this.GetComponent<Rigidbody2D>();

        coroutine = ThrowPie(shotWaitTime);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update () {
        if (count > 100)
        {
            float dx = Input.GetKey(KeyCode.D) ? +1 : Input.GetKey(KeyCode.A) ? -1 : 0;
            float dy = Input.GetKey(KeyCode.W) ? +1 : Input.GetKey(KeyCode.S) ? -1 : 0;
            float normalizeScale = Mathf.Sqrt(dx * dx + dy * dy);
            if (normalizeScale == 0)
            {
                if (Mathf.Abs(rb.velocity.x) < 1.0)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
                if (Mathf.Abs(rb.velocity.y) < 1.0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                }
                rb.AddForce(new Vector2(-Normalize(rb.velocity.x) * speed * 3, -Normalize(rb.velocity.y) * speed * 3));
                return;
            }
            rb.velocity = rb.velocity.magnitude < speed ? rb.velocity : rb.velocity * speed / rb.velocity.magnitude;
            float speedScale = speed / normalizeScale;
            rb.AddForce(new Vector2(dx * speedScale * 3, dy * speedScale * 3));
        }
    }

    private float Normalize(float f)
    {
        if (f == 0) return 0;
        return f / Mathf.Abs(f);
    }

    IEnumerator ThrowPie(float waittime) {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            pt.Shot(tf);
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
            Destroy(this.gameObject);
        }
    }
}
