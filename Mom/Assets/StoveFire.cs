using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveFire : Activable 
{
	public override void Toggle() 
	{
		if(GameStatus.Instance.MakeFood) {
			DialogController.Instance.Say("Ire a ver si mamá quiere un poco.");
			GameStatus.Instance.MomSlept = true;
			gameObject.SetActive(false);
		}
	}
}
