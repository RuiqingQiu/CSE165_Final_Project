/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;
using Leap;

// The model for our skeletal hand made out of various polyhedra.
using UnityEngine.UI;


public class SkeletalHand : HandModel {

  protected const float PALM_CENTER_OFFSET = 0.0150f;	
  public GameObject palm;
  public GameObject forearm;
  public GameObject wristJoint;
  private GameObject player;
  protected Frame frame;
  public Button scale;
  public Button jump;
  private Button[] buttons;
  private int button_num;
  private int count = 0;
  private Button current_button;
  float delay = 0.0f;
  void Start() {
    // Ignore collisions with self.
    Leap.Utils.IgnoreCollisions(gameObject, gameObject);
    player = GameObject.Find("Player") as GameObject;
	buttons = UnityEngine.UI.Button.FindObjectsOfType(typeof(Button)) as Button[];	
	foreach (Button b in buttons) {
		//Debug.Log (b.name);
		if(b.name.Equals("Scale")){
			scale = b;
		}	
		button_num++;
	}
  }

  public override void InitHand() {
    SetPositions();
  }


  public override void UpdateHand() {
    SetPositions();	
    delay += Time.deltaTime;
    Debug.Log("delay is " + delay);
	//Debug.Log (left_hand.GetPalmNormal());
	//Debug.Log (left_hand.GetPalmDirection());
	//Debug.Log (GetPalmDirection());
		
	if(GetLeapHand().IsLeft){
		//Debug.Log ("left");
		if(player){
			
			if (GetPalmDirection().y > 0.2f) {
				player.GetComponent<Rigidbody>().AddForce (player.transform.forward*20);
				Debug.Log ("moving forward");
			}
			else if(GetPalmDirection().y < -0.2f){
				player.GetComponent<Rigidbody>().AddForce (player.transform.forward*-20);
				Debug.Log ("moving backward");
			}
			if (GetPalmDirection().x > 0.4f) {
				player.GetComponent<Rigidbody>().AddTorque (player.transform.up * 1);
				Debug.Log ("turning right");		
			}
			else if (GetPalmDirection().x < -0.3f) {
				player.GetComponent<Rigidbody>().AddTorque (player.transform.up * -1);
				Debug.Log ("turning left");	
			}
		}
	}
	else if(GetLeapHand().IsRight){
		//Debug.Log ("right");
		//Debug.Log (player);
		Debug.Log (GetPalmNormal());
		if(player){
			if(delay > 2.0f){
				if(current_button == null || current_button.image.color != Color.green){
				delay = 0;
				Debug.Log ("next item");
				count = (count + 1) % button_num;
				int local = 0;
				foreach (Button b in buttons) {
					if(local == count){
						b.image.color = Color.red;
						current_button = b;
					}
					else{
						b.image.color = Color.white;
					}	
					local++;
				}
				}
			}
			if(GetPalmNormal().y > 0){
				if(current_button != null){
					current_button.image.color = Color.green;
				}
			}	
			else{
				if(current_button != null){
					current_button.image.color = Color.red;
				}
			}		
			CubePlayerController pc = player.GetComponent<CubePlayerController>();
			int total = pc.itemlist.Count;
			if(pc.itemlist.Count > 0){
				if(scale)
					scale.image.color = Color.red;
				Debug.Log ("trigger");	
				pc.itemlist[0].trigger(player);
			}
		}
	}
 }

  protected Vector3 GetPalmCenter() {
	//Debug.Log (GetPalmDirection());	
    Vector3 offset = PALM_CENTER_OFFSET * Vector3.Scale(GetPalmDirection(), transform.localScale);
    return GetPalmPosition() - offset;
  }


  protected void SetPositions() {
    for (int f = 0; f < fingers.Length; ++f) {
      if (fingers[f] != null)
        fingers[f].InitFinger();
    }

    if (palm != null) {
      palm.transform.position = GetPalmCenter();
      palm.transform.rotation = GetPalmRotation();
    }

    if (wristJoint != null) {
      wristJoint.transform.position = GetWristPosition();
      wristJoint.transform.rotation = GetPalmRotation();
    }

    if (forearm != null) {
      forearm.transform.position = GetArmCenter();
      forearm.transform.rotation = GetArmRotation();
    }
  }
}




