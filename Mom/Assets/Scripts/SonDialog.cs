using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonDialog : MonoBehaviour 
{
	GameObject _obj;
	Text _text;

	void Awake() {
		_obj = transform.Find("text_dialog").gameObject;
		_text = _obj.GetComponent<Text>();
		_obj.SetActive(false);
	}

	void Start () {
		DialogController.Instance.OnSonDialog += _Say;		
	}
	

	Coroutine _coroutine;
	void _Say(string text){
		if(_coroutine!=null)
			StopCoroutine(_coroutine);

		_coroutine =StartCoroutine(SayAndWait(text));
	}


	IEnumerator SayAndWait(string text) {
		_obj.SetActive(true);
		_text.text = text;
		yield return new WaitForSeconds(5f);
		_obj.SetActive(false);

		_coroutine = null;
	}
}
