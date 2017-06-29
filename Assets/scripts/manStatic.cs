using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manStatic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Transform> ().eulerAngles.z != 0)
			GetComponent<Transform> ().eulerAngles = new Vector3(GetComponent<Transform> ().eulerAngles.x,GetComponent<Transform> ().eulerAngles.y,0f);
	}
}
