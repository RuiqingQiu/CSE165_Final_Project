﻿using UnityEngine;
using System.Collections;

public class KeyboardInputInterface : MonoBehaviour {

	CubePlayerController ctrl;
	private bool isWdown = false;
	private bool isAdown = false;
	private bool isDdown = false;

	// Use this for initialization
	void Start () {
		ctrl = gameObject.GetComponent<CubePlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.W)) {
			isWdown = true;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			isAdown = true;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			isDdown = true;
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			isWdown = false;
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			isAdown = false;
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			isDdown = false;
		}

		UpdatePlayerCtrl ();
	}

	void UpdatePlayerCtrl()
	{
		if (isWdown) {
			ctrl.Move (ctrl.transform.forward);
		}
		if (isAdown) {
			ctrl.Rotate(1);
		}
		if (isDdown) {
			ctrl.Rotate(-1);
		}

	}
}
