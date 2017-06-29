using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPrueba : MonoBehaviour {
	public TextMesh text;
	// Use this for initialization
	void Start () {
		Instantiate (text, GetComponent<Transform> ().position, GetComponent<Transform> ().rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
