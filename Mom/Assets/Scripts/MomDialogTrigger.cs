using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomDialogTrigger : MonoBehaviour 
{
	bool started=false;

	void OnTriggerEnter(Collider other) {
		if(other.tag=="Player"&&!started){
			started=true;
			StartCoroutine(MomDialog());
		}	
	}

	IEnumerator MomDialog() {
		yield return DialogController.Instance.FirstMomDialog();
		GameStatus.Instance.MakeFood = true;
		Destroy(this,.1f);
	}
}
