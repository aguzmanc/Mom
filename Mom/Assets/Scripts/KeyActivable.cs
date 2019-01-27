using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyActivable : Activable {

	public override void Toggle() {
		GameStatus.Instance.HasKey = true;
		DialogController.Instance.Say("Ahora puedo usarlo en la puerta!");
		Destroy(gameObject);
	}
}
