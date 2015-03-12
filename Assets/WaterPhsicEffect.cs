using UnityEngine;
using System.Collections;

public class WaterPhsicEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		//Destroy(other.gameObject);
		//Debug.Log("water");
		if (other.attachedRigidbody){
			other.attachedRigidbody.AddForce(Vector3.up * 15);        
		}
	}
}
