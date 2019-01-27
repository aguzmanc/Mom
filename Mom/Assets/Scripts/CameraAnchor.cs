using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchor : MonoBehaviour 
{
	public string PreviousRoomName;
	public string NextRoomName;

	void OnTriggerEnter(Collider other) {
		if(other.tag=="Player"){
			CameraRig rig = GameObject.FindObjectOfType<CameraRig>();
			if(rig!=null)
				rig._target = transform.parent;

			GameObject ob = GameObject.Find(PreviousRoomName);
			FadeRoom room = null;
			if(ob!=null){
				room = ob.GetComponent<FadeRoom>();
				if(room!=null) room.Hide();
			}

			ob = GameObject.Find(NextRoomName);
			if(ob!=null){
				room = ob.GetComponent<FadeRoom>();
				if(room!=null) room.Show();
			}
		}
	}
}
