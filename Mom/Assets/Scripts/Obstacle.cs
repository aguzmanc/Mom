using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour 
{
	public List<Floor> floors;

	void Awake(){
		floors = new List<Floor>();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Floor"){
			other.GetComponent<Floor>().Walkable = false;
			floors.Add(other.GetComponent<Floor>());
			
		}
	}
}
