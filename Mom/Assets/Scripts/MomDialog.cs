using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomDialog : SonDialog 
{
	public override void Start () {
		DialogController.Instance.OnMomDialog += _Say;		
	}
}
