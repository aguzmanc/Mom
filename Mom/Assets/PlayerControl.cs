using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour 
{
	float _hh=0, _vv=0;
	Transform _rot;
	Animator _anim;

	[Range(0f, 1f)]
	public float MovementThreshold=0.5f;

	void Awake(){
		_rot = transform.Find("rot");
		_anim = GetComponent<Animator>();
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

			Vector3 aheadPos = _rot.position + new Vector3(x, 0, z);
			aheadPos = new Vector3(aheadPos.x, _rot.position.y+1, aheadPos.z);

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
