using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmellTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.tag=="Player"){
			DialogController.Instance.Say("El aroma de esta comida es increíble.");
			Destroy(this);
		}	
	}
}
