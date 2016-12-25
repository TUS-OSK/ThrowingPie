using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangMaker : MonoBehaviour {

    public GameObject wang;
    public GameObject bossWang;
    Transform tf;
    public float waitTime=1.0f;
    private IEnumerator coroutine;

    // Use this for initialization
    void Start() {
        tf = this.GetComponent<Transform>();

        coroutine = Make();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator Make() {
        int count = 0;
        while (true)
        {
            if (count < 20)
            {
                Instantiate(wang, new Vector3(Random.Range(-12.0f, 12.0f), 6,0), Quaternion.identity);
                // waittime待つ
                yield return new WaitForSeconds(waitTime);
            }
            else
            {
                tf.position = new Vector3(tf.position.x, 5,0);
                Instantiate(bossWang, tf);
                yield return new WaitForSeconds(10000000);
            }
            count++;
        }
    }
   
}