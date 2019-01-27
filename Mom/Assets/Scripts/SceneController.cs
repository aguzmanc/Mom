using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour 
{
	void Start () {
		SceneManager.LoadScene("Bedroom", LoadSceneMode.Additive);
		SceneManager.LoadScene("Attic", LoadSceneMode.Additive);
		SceneManager.LoadScene("LivingRoom", LoadSceneMode.Additive);
		SceneManager.LoadScene("Kitchen", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
