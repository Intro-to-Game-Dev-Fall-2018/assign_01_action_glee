using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	public float speed = 0.1f;
	Vector3 originalPos;
	// Use this for initialization
	void Start () {
		originalPos = transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.position += speed * Vector3.right;

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("Loop"))

			transform.position = originalPos + new Vector3(-25f, 0.0f, 0.0f);
		if (other.gameObject.CompareTag ("Loop2"))

			transform.position = originalPos + new Vector3(1f, 0.0f, 0.0f);
			
	}
}
