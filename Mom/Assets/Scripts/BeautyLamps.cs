using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeautyLamps : Lamp
{
	public override void Toggle(){
		base.Toggle();

		string[] strs = new string[3];
		if(Active){
			strs[0] = "Que lindo color";
			strs[1] = "Deberían hacer mas lámparas como estas";
			strs[2] = "Hermoso!";
		} else{
			strs[0] = "No la apagues!";
			strs[1] = "Era un lindo color";
			strs[2] = "Mas oscuridad, que lamentable";
		}

		DialogController dialogs = DialogController.Instance;
		dialogs.Say(strs[Random.Range(0, strs.Length)]);
	}
}
