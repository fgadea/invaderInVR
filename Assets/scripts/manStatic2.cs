using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manStatic2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Transform> ().position.y != 0f)
			GetComponent<Transform> ().position = new Vector3 (GetComponent<Transform> ().localPosition.x, 0f, GetComponent<Transform> ().localPosition.z);
		
	}
}
