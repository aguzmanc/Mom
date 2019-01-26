using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour 
{
	static DialogController _instance;
	public static DialogController Instance{get{return _instance;}}

	public delegate void SonDialogHandler(string text);
	public SonDialogHandler OnSonDialog;

	void Awake() {
		_instance = this;
	}

	void Start () {
		StartCoroutine(_KeyDialog());
	}

	IEnumerator _KeyDialog() {
		yield return new WaitForSeconds(6f);
		Say("Odio los días de lluvia y truenos");
		yield return new WaitForSeconds(4);
		Say("Contemplar mi color favorito me tranquilizará");
		yield return new WaitForSeconds(5);
		Say("Y de paso me ayudará a encontrar esa LLAVE");
	}


	public void Say(string text){
		if(OnSonDialog!=null)
			OnSonDialog(text);
	}
}
