using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour 
{
	static LightsController _instance;
	public static LightsController Instance{get{return _instance;}}

	Renderer[] _rends;

	void Awake(){
		_instance = this;
	}

	void Start () {
		_rends = GameObject.FindObjectsOfType<Renderer>();
	}

	public void UpdateLights(){
		for(int i=0;i<_rends.Length;i++)
			RendererExtensions.UpdateGIMaterials(_rends[i]);
	}
}
