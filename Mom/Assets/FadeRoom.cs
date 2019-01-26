using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeRoom : MonoBehaviour 
{
	public bool ActiveByDefault = false;

	void Start() {
		StartCoroutine(LateStart());
	}

	IEnumerator LateStart(){
		yield return new WaitForSeconds(.2f);
		if(ActiveByDefault)
			Show();
		else
			Hide();
	}

	public void Hide(){
		for(int i=0;i<transform.childCount;i++) {
			transform.GetChild(i).gameObject.SetActive(false);
		}
	}

	public void Show(){
		for(int i=0;i<transform.childCount;i++) {
			transform.GetChild(i).gameObject.SetActive(true);
		}
	}
}
