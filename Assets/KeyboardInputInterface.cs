using UnityEngine;
using System.Collections;

public class KeyboardInputInterface : MonoBehaviour {

	CubePlayerController ctrl;
	private bool isWdown = false;
	private bool isAdown = false;
	private bool isDdown = false;
	private bool isSdown = false;
	private bool isSpaceDown = false;
	private bool isRDown = false;
	// Use this for initialization
	void Start () {
		ctrl = gameObject.GetComponent<CubePlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.R)){
			isRDown = true;
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			isWdown = true;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			isAdown = true;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			isDdown = true;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			isSdown = true;
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			isSpaceDown = true;
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
		if (Input.GetKeyUp (KeyCode.S)) {
			isSdown = false;
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			isSpaceDown = false;
		}
		if(Input.GetKeyUp(KeyCode.R)){
			isRDown = false;
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
		if (isSdown) {
			ctrl.Move (-ctrl.transform.forward);
		}
		if(isSpaceDown){
			ctrl.Jump();
		}
		if(isRDown){
			ctrl.Reset();
		}
	}
}
