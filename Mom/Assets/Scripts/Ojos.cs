using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojos : MonoBehaviour 
{
	[Range(0.1f,10f)]
	public float MinTime = 0.2f;
	[Range(0.1f,10f)]
	public float MaxTime = 5f;


	void Start () {
		StartCoroutine(Blink());
	}
	
	IEnumerator Blink(){
		while(true){
			yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
			GetComponent<Animator>().SetTrigger("Parpadear");
		}
	}
}
