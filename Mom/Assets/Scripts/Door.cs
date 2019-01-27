using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activable 
{
	public GameObject LockedSoundPrototype;
	public GameObject OpenedSoundPrototype;

	public override void Toggle() 
	{
		if(GameStatus.Instance.HasKey){
			transform.Find("a").localRotation = Quaternion.Euler(0,90,0);
			transform.Find("b").localRotation = Quaternion.Euler(0,-90,0);
			GameObject obj = (GameObject)Instantiate(OpenedSoundPrototype);
			Destroy(obj, 3);
			Destroy(GetComponent<Obstacle>());
			Destroy(this);
		}

		GameObject lockedObjSound = (GameObject)Instantiate(LockedSoundPrototype);
		Destroy(lockedObjSound, 3);
	}
}
