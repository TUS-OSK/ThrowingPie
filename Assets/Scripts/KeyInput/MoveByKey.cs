using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rb;
	float speed = 30f;

	void Start () {
		this.rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float dx = Input.GetKey(KeyCode.D) ? +1 : Input.GetKey(KeyCode.A) ? -1 : 0;
		float dy = Input.GetKey(KeyCode.W) ? +1 : Input.GetKey(KeyCode.S) ? -1 : 0;
		float normalizeScale = Mathf.Sqrt(dx*dx + dy*dy);
		if (normalizeScale == 0) {
			Debug.Log(Mathf.Abs(rb.velocity.x));
			if (Mathf.Abs(rb.velocity.x)<1.0e-5f) {
				rb.velocity = new Vector2(0,rb.velocity.y);
			}
			if (Mathf.Abs(rb.velocity.y)<1.0e-5f) {
				rb.velocity = new Vector2(rb.velocity.x,0);
			}
			rb.AddForce(new Vector2(-Normalize(rb.velocity.x)*speed,-Normalize(rb.velocity.y)*speed));
			return;
		}
		float speedScale = speed/normalizeScale;
		rb.AddForce(new Vector2(dx*speedScale, dy*speedScale));
	}

	private float Normalize(float f) {
		if (f == 0) return 0;
		return f / Mathf.Abs(f);
	}
}
