﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalObject : MonoBehaviour 
{
	GameObject _mainObject;

	public List<Activable> Required;
	public List<Activable> Excluded;

	void Awake() {
		_mainObject = transform.Find("object").gameObject;
		_mainObject.SetActive(false);
	}

	void Start(){
		if(Required!=null)
			for(int i=0;i<Required.Count;i++)
				Required[i].OnStateChange+=_CheckStates;
			
		if(Excluded!=null)
			for(int i=0;i<Excluded.Count;i++)
				Excluded[i].OnStateChange += _CheckStates;
	}

	void OnDestroy(){
		if(Required!=null)
			for(int i=0;i<Required.Count;i++)
				Required[i].OnStateChange -= _CheckStates;
			
		if(Excluded!=null)
			for(int i=0;i<Excluded.Count;i++)
				Excluded[i].OnStateChange -= _CheckStates;
	}

	void _CheckStates(object src, System.EventArgs args) {
		bool req = true;
		if(Required!=null){
			for(int i=0;i<Required.Count;i++)
				if(Required[i].Active==false){
					req = false;
					break;
				}
		}

		bool excl = true;
		if(Excluded!=null)
			for(int i=0;i<Excluded.Count;i++){
				if(Excluded[i].Active){
					excl = false;
					break;
				}
			}
		
		if(req&&excl) {
			StartCoroutine(KeyFound());
		}
	}

	IEnumerator KeyFound(){
		_mainObject.SetActive(true);
		yield return new WaitForSeconds(.2f);
		DialogController.Instance.Say("ESO!!.. Mira, allá estaba la llave");
		yield return new WaitForSeconds(4f);
		DialogController.Instance.Say("Agarremos la llave, veamos si mamá sigue en el sofá...");
		Destroy(this);
	}
}
