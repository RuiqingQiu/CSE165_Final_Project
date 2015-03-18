using UnityEngine;
using System.Collections;

public class JumpItem : IItem{
	public string name = "JUMP";
	public float JumpSpeed = 100.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	override public void trigger(GameObject player)
	{
		Debug.Log("Trigger Scale");
		if(player.transform.localScale.magnitude < 1){
			return;
		}
		player.GetComponent<Rigidbody>().AddForce(Vector3.up *JumpSpeed);
	}
}

