using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider player){
		if(player.tag.Equals("Player")){
			Debug.Log ("score!");
			CubePlayerController.total_score += 1;
			gameObject.SetActive(false);
		}
	}
}
