using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour 
{
	public Transform _target;

	[Range(0.1f, 5f)]
	public float Smoothness;

	void Update() {
		Vector3 pos = transform.position;
		if(_target!=null)
			transform.position = Vector3.Lerp(pos, _target.position, Smoothness * Time.deltaTime);
	}
}
