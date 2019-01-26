using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightLamp : Lamp 
{
	public override void Toggle(){
		base.Toggle();

		DialogController dialogs = DialogController.Instance;

		string[] strs = new string[3];
		if(Active){
			strs[0] = "Mucho brillo argh!";
			strs[1] = "Quema mis ojos";
			strs[2] = "Mejor apaguemos estas";
		} else{
			strs[0] = "Gracias!";
			strs[1] = "Se siente mejor tener esta luz apagada";
			strs[2] = "Un gran alivio";
		}

		dialogs.Say(strs[Random.Range(0, strs.Length)]);
		
	}
}
