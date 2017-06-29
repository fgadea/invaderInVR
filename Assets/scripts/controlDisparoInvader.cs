using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlDisparoInvader : MonoBehaviour {
	public GameObject disparo;
	public Transform posDisparo;
	public float esperaPpal;
	public float frequency;

	private float timer;
	//private float effectsBetweenBullets = 0.3f;
	// Use this for initialization


	void Start () {
		StartCoroutine ("shoot");
		InvokeRepeating ("shoot", esperaPpal, frequency);
		GetComponent<MeshRenderer> ().material.color = new Color (0, 234, 255, 255);
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator shoot ()
	{
		yield return new WaitForSeconds (5f);
		Instantiate (disparo, posDisparo.position, posDisparo.rotation);
		yield return StartCoroutine(shoot());
	}
}
