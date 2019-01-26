using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Activable 
{
	Material _mat;
	Color _originalColor;

	public GameObject SoundPrototype;

	void Awake(){
		_mat = GetComponent<Renderer>().material;
		_originalColor = _mat.GetColor("_EmissionColor");
	}

	public override void Toggle(){
		if(Active){
			_mat.DisableKeyword("_EMISSION");
			_mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
			_mat.SetColor("_EmissionColor", Color.black);	
		} else {
			_mat.EnableKeyword("_EMISSION");
			_mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
			_mat.SetColor("_EmissionColor", _originalColor);
		}

		GameObject obj = (GameObject)Instantiate(SoundPrototype);
		Destroy(obj, 2);

		Active = !Active;
		LightsController.Instance.UpdateLights();
	}
}
