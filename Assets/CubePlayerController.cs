﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CubePlayerController : MonoBehaviour {
	public List<IItem> itemlist = new List<IItem>();
	public SkeletalHand left_hand;
	public static int total_score = 0;
	public GameObject text;
	public GameObject timer_text;
	Rigidbody phisicalBody;
	float timer = 0.0f;
	float speed = 20.0f;
	// Use this for initialization
	void Start () {
		Debug.Log("Initializing player controller...");
		phisicalBody = gameObject.GetComponent<Rigidbody> ();
		if (!phisicalBody) {
			Debug.LogError("phisical body of cube player is missing!");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		timer_text.GetComponent<Text>().text = "Timer: " + timer + "s";
		text.GetComponent<Text>().text = "Score: " + total_score;
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float y = Input.GetAxis ("Jump") * Time.deltaTime * speed;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		
		//Debug.Log (x + " " + y + " " + z);
		transform.Translate(x, y, z);
		//add resist force
		//phisicalBody.AddForce (new Vector3(0,1,0));
		
				
		phisicalBody.velocity = Vector3.Scale(phisicalBody.velocity ,new Vector3(0.98f , 0.98f, 0.98f));
		phisicalBody.angularVelocity = Vector3.Scale(phisicalBody.angularVelocity ,new Vector3(0.98f , 0.98f, 0.98f));

		//phisicalBody.angularVelocity.Scale(new Vector3(0.55f , 0.55f, 0.55f));
		if (phisicalBody.velocity.magnitude > 10) {
			phisicalBody.velocity = phisicalBody.velocity.normalized*10;
		}
		if (phisicalBody.angularVelocity.magnitude > 4) {
			phisicalBody.angularVelocity = phisicalBody.angularVelocity.normalized*4;
		}
	}

	public bool Move(Vector3 direction)
	{
		//Debug.Log ("Move being called");
		//phisicalBody.AddForce (direction*20);
		transform.Translate(direction);
		
		return true;
	}

	//positive right turn
	//negative left turn
	public bool Rotate(float value)
	{
		transform.Translate(new Vector3(-value, 0, 0));
		//phisicalBody.AddTorque (transform.up * -value);
		return true;
	}
	
	public void Jump(){
		gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up *100.0f);
	}
	
	public bool Pick(IItem item)
	{
		Debug.Log("pick something");
		itemlist.Add(item);
		return true;
	}
	public void Reset(){
		gameObject.transform.rotation = Quaternion.identity;
	}
}
