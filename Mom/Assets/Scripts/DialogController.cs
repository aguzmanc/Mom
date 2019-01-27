using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour 
{
	static DialogController _instance;
	public static DialogController Instance{get{return _instance;}}

	public delegate void DialogHandler(string text);
	public DialogHandler OnSonDialog;
	public DialogHandler OnMomDialog;

	void Awake() {
		_instance = this;
	}

	void Start () {
		Say("");MomSays("");
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

	public IEnumerator FirstMomDialog(){
		MomSays("¿Ya recogiste tu ropa de la terraza hijito?");
		yield return new WaitForSeconds(3f);
		Say("No pude mami, ya debe estar todo mojado!");
		yield return new WaitForSeconds(3f);
		MomSays("Este chico, que descuidado es");
		yield return new WaitForSeconds(3f);
		MomSays("Mas bien, servite comidita, esta calentando");
		yield return new WaitForSeconds(3f);
		Say("Ya mami");
	}




	public void Say(string text){
		if(OnSonDialog!=null)
			OnSonDialog(text);
	}

	public void MomSays(string text){
		if(OnMomDialog!=null)
			OnMomDialog(text);
	}
}
