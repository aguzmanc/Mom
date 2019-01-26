using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour 
{
	float x, y;
	Light _light;

	public float MaxIntensity=11;
	public float MinIntensity=5;
	public float Velocity=2f;

	void Awake () {
		_light = GetComponent<Light>();
	}
	
	void Update () {
		_light.intensity = MinIntensity + Mathf.PerlinNoise(x,y) * (MaxIntensity-MinIntensity);
		x += Velocity * Time.deltaTime;
		y += Velocity * Time.deltaTime;
	}
}
