using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour 
{
	PlayerControl _player;

	public Activable Item;

	void Update(){
		if(_player!=null) {
			if(Input.GetButtonDown("Fire1")){
				if(Vector3.Dot(_player.Forward, transform.forward) > 0.1f)
					Item.Toggle();
			}
		}
	}



	void OnTriggerEnter(Collider other) {
		if(other.tag=="Player"){
			_player = other.GetComponentInParent<PlayerControl>();
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.tag=="Player")	{
			_player=null;
		}
	}
}
