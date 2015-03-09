using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	float speed = 2.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float y = Input.GetAxis ("Jump") * Time.deltaTime * speed;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(x, y, z);
	}
}
