using UnityEngine;
using System.Collections;

public class CameraMoveController : MonoBehaviour {
	Transform followingTarget;
	bool HasParent = false;
	Vector3 localPos;
	// Use this for initialization
	void Start () {
		followingTarget = transform.parent;
		if (followingTarget) {
			HasParent = true;
			localPos = transform.localPosition;
			transform.parent = transform.parent.parent;

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!HasParent) {
			return;
		}
		Vector3 nextpos = Vector3.Lerp (transform.position, followingTarget.localToWorldMatrix.MultiplyPoint(localPos), 0.05f);
		transform.position = nextpos;

		Quaternion targetQ = new Quaternion();
		targetQ.SetFromToRotation (nextpos, followingTarget.position);

		Quaternion nextRot = Quaternion.Slerp (transform.rotation, targetQ,0.1f);
		transform.rotation = nextRot;
		transform.LookAt (followingTarget.position);

		//Debug.Log (nextpos);
	}
}
