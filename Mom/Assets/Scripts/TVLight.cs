using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVLight : Activable 
{
	float x,y;
	Light _light;

	public float Velocity=0.1f;
	public float MaxIntensity=4f;

	public Gradient Gradient;

	void Awake() {
		_light = GetComponent<Light>();
	}

	void Start () {
		x=0;y=0;	
		StartCoroutine(ChangeColor());	
	}
	
	void Update () {
		x+=Time.deltaTime*Velocity;
		y+=Time.deltaTime*Velocity;

		_light.intensity = Mathf.PerlinNoise(x,y) * MaxIntensity;
		_light.color = Gradient.Evaluate(Mathf.PerlinNoise(x,y));
	}

	public override void Toggle(){
		_light.enabled = !_light.enabled;

		_NotifyChanges();
	}

	IEnumerator ChangeColor(){
		while(true){
			yield return new WaitForSeconds(Random.Range(2f, 5f));
			x+=30;y-=20;
		}
	}
}
