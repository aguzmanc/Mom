using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowThunder : MonoBehaviour 
{
    public Light _light;
    public Material _mat;

    void Awake() {
        Renderer rend = GetComponent<Renderer>();
        if(rend==null)
            rend = GetComponentInChildren<Renderer>();

        _mat = rend.material;

        _light = GetComponent<Light>();
        if(_light==null)
            _light = GetComponentInChildren<Light>();
    }


    void Start() {
        LightsController.Instance.OnThunderIntensity += _OnThunderIntensity;
    }


    void _OnThunderIntensity(float intensity)
    {
        if(_light!=null){
            _light.intensity = intensity * 30;
        }

        if(_mat!=null){
            Color col = Color.Lerp(Color.black, Color.white, intensity);
            _mat.SetColor("_Color", col);
            _mat.SetColor("_EmissionColor",col);
        }
    }
}
