using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
	static GameStatus _instance;
	public static GameStatus Instance{get{return _instance;}}
	
	public bool HasKey;
	public bool MakeFood;
	public bool MomSlept;

	void Awake(){
		_instance = this;
	}

	void Start () {
		HasKey = false;
	}
}
