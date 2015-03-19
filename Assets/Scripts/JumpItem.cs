using UnityEngine;
using System.Collections;

public class JumpItem : IItem{
	public string name = "JUMP";
	public float JumpSpeed = 20000.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	override public void trigger(GameObject player)
	{
		Debug.Log("Trigger Jump");	
		float y = JumpSpeed * Time.deltaTime * 0.2f;
		Debug.Log (y);
		player.transform.Translate(0, y, 0);
		//player.GetComponent<Rigidbody>().AddForce(Vector3.up *JumpSpeed);
	}
}

