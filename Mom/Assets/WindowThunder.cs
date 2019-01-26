using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowThunder : MonoBehaviour 
{
    Light _light;
    Material _mat;

	public AnimationCurve Curve;
    [Range(0.1f, 5f)]
    public float TimeOfAnimation;
    public GameObject ThunderSoundPrototype;

    void Awake() {
        _light = GetComponentInChildren<Light>();
        _mat = GetComponentInChildren<Renderer>().material;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(Thunder());
        }
    }

    IEnumerator Thunder()
    {
        float remain = TimeOfAnimation;
        GameObject sound = (GameObject)Instantiate(ThunderSoundPrototype);
        Destroy(sound, 12);
        while(remain>0){
            float val = Curve.Evaluate(1f-(remain/TimeOfAnimation));

            _light.intensity = val * 30;
            Color col = Color.Lerp(Color.black, Color.white, val);
            _mat.SetColor("_Color", col);
            _mat.SetColor("_EmissionColor",col);

            yield return new WaitForEndOfFrame();
            remain -= Time.deltaTime;
        }
    }
}
