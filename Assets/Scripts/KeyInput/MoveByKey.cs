using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour {

	// Use this for initialization
	Transform transform;
	float speed = 0.3f;

	void Start () {
		this.transform = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		float dx = Input.GetKey(KeyCode.D) ? +1 : Input.GetKey(KeyCode.A) ? -1 : 0;
		float dy = Input.GetKey(KeyCode.W) ? +1 : Input.GetKey(KeyCode.S) ? -1 : 0;
		float normalizeScale = Mathf.Sqrt(dx*dx + dy*dy);
		float speedScale = speed/normalizeScale;
		transform.position = new Vector3(
			transform.position.x + dx*speedScale,
			transform.position.y + dy*speedScale,
			0
		);
	}
}
