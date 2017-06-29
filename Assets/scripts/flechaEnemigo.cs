using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flechaEnemigo : MonoBehaviour {
	public GameObject flechaParent;
	private Vector3 posFlecha;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setPosition(Vector3 position){
		posFlecha = position;
	}
}
