using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : MonoBehaviour {

	void Start () {
		StartCoroutine(WaitAndSleep());
	}

	IEnumerator WaitAndSleep()
	{
		GameStatus stat = GameStatus.Instance;
		yield return new WaitUntil(()=>stat.MomSlept);
		Animator anim = GetComponent<Animator>();
		anim.enabled = true;
		anim.SetTrigger("Sleep");
	}
}
