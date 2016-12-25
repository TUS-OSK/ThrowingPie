using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rb;
	float speed = 10f;

	void Start () {
		this.rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float dx = Input.GetKey(KeyCode.D) ? +1 : Input.GetKey(KeyCode.A) ? -1 : 0;
		float dy = Input.GetKey(KeyCode.W) ? +1 : Input.GetKey(KeyCode.S) ? -1 : 0;
		float normalizeScale = Mathf.Sqrt(dx*dx + dy*dy);
		if (normalizeScale == 0) {
			if (Mathf.Abs(rb.velocity.x)<1.0) {
				rb.velocity = new Vector2(0,rb.velocity.y);
			}
			if (Mathf.Abs(rb.velocity.y)<1.0) {
				rb.velocity = new Vector2(rb.velocity.x,0);
			}
			rb.AddForce(new Vector2(-Normalize(rb.velocity.x)*speed*3,-Normalize(rb.velocity.y)*speed*3));
			return;
		}
		rb.velocity = rb.velocity.magnitude < speed ? rb.velocity : rb.velocity * speed / rb.velocity.magnitude;
		float speedScale = speed/normalizeScale;
		rb.AddForce(new Vector2(dx*speedScale*3, dy*speedScale*3));
	}

	private float Normalize(float f) {
		if (f == 0) return 0;
		return f / Mathf.Abs(f);
	}
}
