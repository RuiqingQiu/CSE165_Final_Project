using UnityEngine;
using System.Collections;

public class ScaleItem : IItem{
	public string name = "SCALE";
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
		player.transform.localScale = player.transform.localScale * 0.99f;
	}
}
