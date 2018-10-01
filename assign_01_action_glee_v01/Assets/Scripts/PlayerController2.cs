using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour {

	public float speed = 0.1f;
	Vector3 originalPos;

	public Text countText2;
	private int count2;
	public Text winText;

	public bool win = false;

	public AudioClip quack;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {

		count2 = 0;
		originalPos = transform.position;
		winText.text = "";

		SetCountText ();

		audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.position += speed*Vector3.up;

		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += speed*Vector3.down;
		}

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
	
		transform.position = originalPos;

		audioSource.PlayOneShot(quack,0.7f);

		if (other.gameObject.CompareTag ("Finish"))
			count2 = count2 + 1;

			SetCountText ();
		}
	void SetCountText()
	{
		
		countText2.text = count2.ToString ();

		if (count2 >= 10) {
			winText.text = "PLAYER 2 WINS!";
			win = true;
			Time.timeScale = 0;
		}
	}
}

