using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {
	public IItem item;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider player)
	{
		Debug.Log("trigger in pickable");
		CubePlayerController pc = player.GetComponent<CubePlayerController>();
		if(pc)
		{
			if(item!=null)
			{
				pc.Pick(item);
				gameObject.SetActive(false);	
			}
		}
	}
}
