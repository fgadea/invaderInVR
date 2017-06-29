using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColor : MonoBehaviour {
	public GameObject invader;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().color = invader.GetComponentInChildren<MeshRenderer> ().material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
