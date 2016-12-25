using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieThrower : MonoBehaviour
{

    // 移動スピード
    public float speed;

    // 弾を撃つ間隔
    public float shotDelay;

    // 弾のPrefab
    public GameObject pie;

    // 弾を撃つ方向
    public Vector2 direction;

    // 弾の作成
    public void Shot(Transform origin,Vector2 shotDirection)
    {
        //Instantiate(pie, origin);
        GameObject Ps = Instantiate(pie, origin.position, origin.rotation) as GameObject;
        // Shotスクリプトオブジェクトを取得
        PieScript ps = Ps.GetComponent<PieScript>();
        ps.OnCreate(shotDirection);
    }

    // 機体の移動
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
