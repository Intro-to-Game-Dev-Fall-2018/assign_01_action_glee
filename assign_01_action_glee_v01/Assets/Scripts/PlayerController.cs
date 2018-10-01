using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed = 0.1f;
	Vector3 originalPos;

	public Text countText;
	private int count;

	public Text winText;

	public bool win = false;

	public AudioClip quack;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {

		count = 0;
		originalPos = transform.position;
		winText.text = "";


		SetCountText ();

		audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W)) {
			transform.position += speed*Vector3.up;

		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position += speed*Vector3.down;
		}
			
	}

	void OnTriggerEnter2D(Collider2D other) 
	{ 
		transform.position = originalPos;

		audioSource.PlayOneShot(quack,0.7f);

		if (other.gameObject.CompareTag ("Finish"))
			count = count + 1;

			SetCountText ();


		}
	void SetCountText()
	{
		
		countText.text = count.ToString ();

		if (count >= 10) {
			winText.text = "PLAYER 1 WINS!";
			win = true;
			Time.timeScale = 0;
		}
	}
}

