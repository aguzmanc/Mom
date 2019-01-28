using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpMom : Activable 
{
	public GameObject BackgroundMusic;
	public GameObject Credits;

	void Start () {
		transform.Find("activator").gameObject.SetActive(false);
		StartCoroutine(WaitForSleep());
	}

	IEnumerator WaitForSleep(){
		yield return new WaitUntil(()=>GameStatus.Instance.MomSlept);
		transform.Find("activator").gameObject.SetActive(true);
	}

	public override void Toggle(){
		StartCoroutine(FinalCredits());
	}


	IEnumerator FinalCredits(){
		DialogController dialog = DialogController.Instance;
		transform.Find("activator").gameObject.SetActive(false);

		dialog.Say("Mejor la dejo dormir...");
		yield return new WaitForSeconds(3f);
		dialog.Say("Es el único momento en que tiene algo de descanso...");
		yield return new WaitForSeconds(3f);
		dialog.Say("Si no estuviera, esta casa estaría vacía...");
		yield return new WaitForSeconds(3f);
		dialog.Say("Hace mucho dejó de ser un HOGAR sin ella");
		yield return new WaitForSeconds(1f);
		dialog.Say("Hace mucho dejó de ser un HOGAR sin ella");
		yield return new WaitForSeconds(1f);
		dialog.Say("Hace mucho dejó de ser un HOGAR sin ella");
		yield return new WaitForSeconds(3f);

		LightsController.Instance.Thunder();
		transform.Find("mom").gameObject.SetActive(false);
		GameObject.FindObjectOfType<PlayerControl>().enabled=false;
		transform.Find("music").gameObject.SetActive(true);
		BackgroundMusic.SetActive(false);
		Credits.SetActive(true);
	}
}
