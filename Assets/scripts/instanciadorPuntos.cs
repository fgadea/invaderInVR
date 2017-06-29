using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciadorPuntos : MonoBehaviour {
	public TextMesh puntos;
	// Use this for initialization
	void Start () {
		Instantiate (puntos, GetComponent<Transform> ().position, GetComponent<Transform> ().rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
