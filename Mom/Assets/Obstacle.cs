using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour 
{
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Floor"){
			other.GetComponent<Floor>().Walkable = false;
		}
	}
}
