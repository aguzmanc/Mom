using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour 
{	
	public System.EventHandler OnStateChange;

	public bool Active;
	public virtual void Toggle(){}


	protected void _NotifyChanges(){
		if(OnStateChange!=null)
			OnStateChange(this, System.EventArgs.Empty);
	}
}
