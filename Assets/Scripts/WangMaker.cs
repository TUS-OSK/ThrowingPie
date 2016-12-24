using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangMaker : MonoBehaviour {

    public GameObject wang;
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
    void Update()
    {
    }

    IEnumerator Make() {
        while (true)
        {
            tf.position = new Vector3(tf.position.x + (Random.value - 0.5f) * 2, tf.position.y, tf.position.z);
            Instantiate(wang, tf);
            // waittime待つ
            yield return new WaitForSeconds(waitTime);
        }
    }
   
}