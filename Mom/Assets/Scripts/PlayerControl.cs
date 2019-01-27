using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour 
{
	float _hh=0, _vv=0;
	Transform _rot;
	Animator _anim;
	GameObject _button;

	[Range(0f, 1f)]
	public float MovementThreshold=0.5f;

	public GameObject[] StepSounds;

	public Vector3 Forward{get{
		return _rot.forward;
	}}

	public void HideButton(){_button.SetActive(false);}
	public void ShowButton(){_button.SetActive(true);}

	void Awake(){
		_rot = transform.Find("rot");
		_button = transform.Find("button").gameObject;
		_anim = GetComponent<Animator>();
	}

	void Start() {
		HideButton();
	}




	void Update () {
		float hh = Input.GetAxis("Horizontal");
		float vv = Input.GetAxis("Vertical");

		int x = 0, z=0;

		if(Mathf.Abs(_hh) < MovementThreshold) {
			if(hh >= MovementThreshold)
				z=1;
			if(hh <= -MovementThreshold)
				z=-1;
		}

		if(Mathf.Abs(_vv) < MovementThreshold) {
			if(vv >= MovementThreshold)
				x=-1;
			if(vv <= -MovementThreshold)
				x=1;
		}

		_hh = hh;
		_vv = vv;

		if(x!=0 || z!=0){
			_rot.rotation=Quaternion.LookRotation(new Vector3(x, 0, z));
			_anim.SetTrigger("Move");

			GameObject objSound = (GameObject)Instantiate(
				StepSounds[Random.Range(0, StepSounds.Length)]
			);
			Destroy(objSound, 4);

			Vector3 aheadPos = _rot.position + new Vector3(x, 0, z);
			aheadPos = new Vector3(aheadPos.x, _rot.position.y+1.2f, aheadPos.z);

			RaycastHit[] hits = Physics.RaycastAll(aheadPos, Vector3.down, 2);
			bool allowed = false;
			Floor destinationFloor=null;
			for(int i=0;i<hits.Length;i++) {
				if(hits[i].collider.tag == "Floor") {
					destinationFloor = hits[i].collider.GetComponent<Floor>();
					if(destinationFloor.Walkable){
						allowed = true;
						break;
					}
				}
			}

			if(allowed){
				Vector3 pos = transform.position;
				transform.position = new Vector3(pos.x+x, destinationFloor.transform.position.y, pos.z+z);
			}
		}
	}
}
