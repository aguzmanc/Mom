using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour 
{
	static LightsController _instance;
	public static LightsController Instance{get{return _instance;}}


	public delegate void ThunderIntensityHandler(float intensity);
	public ThunderIntensityHandler OnThunderIntensity;

	Renderer[] _rends;


	public AnimationCurve Curve;
    [Range(0.1f, 5f)]
    public float TimeOfAnimation;
	[Range(2f, 20f)]
	public float MinThunderCycle=12f;
	[Range(3f, 30f)]
	public float MaxThunderCycle=20f;
	public GameObject ThunderSoundPrototype;


	void Awake(){
		_instance = this;
	}

	void Start () {
		_rends = GameObject.FindObjectsOfType<Renderer>();
		StartCoroutine(_ThunderCycle());
	}

	public void UpdateLights(){
		for(int i=0;i<_rends.Length;i++)
			RendererExtensions.UpdateGIMaterials(_rends[i]);
	}


	IEnumerator _ThunderCycle(){
		yield return new WaitForSeconds(5f); // Time to First thunder

		while(true) {
			yield return _Thunder();
			yield return new WaitForSeconds(Random.Range(MinThunderCycle, MaxThunderCycle));
		}
	}


	
	IEnumerator _Thunder()
    {
        float remain = TimeOfAnimation;
        GameObject sound = (GameObject)Instantiate(ThunderSoundPrototype);
        Destroy(sound, 12);
        while(remain>=0){
            float val = Curve.Evaluate(1f-(remain/TimeOfAnimation));

			if(OnThunderIntensity!=null)
				OnThunderIntensity(val);

			UpdateLights();
            yield return new WaitForEndOfFrame();
            remain -= Time.deltaTime;
        }

		if(OnThunderIntensity!=null)
			OnThunderIntensity(0f);
		UpdateLights();
    }
}
