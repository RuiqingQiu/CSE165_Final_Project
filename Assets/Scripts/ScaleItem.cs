using UnityEngine;
using System.Collections;

public class ScaleItem : IItem{
	public string name = "SCALE";
	//0 for shrink and 1 for large
	private int state = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	override public void trigger(GameObject player)
	{
		Debug.Log("Trigger Scale");
		if(state == 0){
			if(player.transform.localScale.magnitude < 5){
				state = 1;
				return;
			}
			player.transform.localScale = player.transform.localScale * 0.99f;
		}
		else if (state == 1){
			if(player.transform.localScale.magnitude > 50){
				state = 0;
				return;
			}
			player.transform.localScale = player.transform.localScale * 1.01f;
		}
		
	}
}
