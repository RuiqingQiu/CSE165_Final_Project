using UnityEngine;
using System.Collections;

public class CubePlayerController : MonoBehaviour {


	Rigidbody phisicalBody;
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
		Debug.Log ("Move being called");
		phisicalBody.AddForce (direction*20);

		return true;
	}

	//positive right turn
	//negative left turn
	public bool Rotate(float value)
	{
		phisicalBody.AddTorque (transform.up * -value);
		return true;
	}

}
