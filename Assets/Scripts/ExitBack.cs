using UnityEngine;
using System.Collections;

public class ExitBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider player){
		if(player.tag.Equals("Player")){
			player.transform.position = new Vector3(-105, 0, 106);
			player.transform.rotation = Quaternion.identity;
		}
	}
}
