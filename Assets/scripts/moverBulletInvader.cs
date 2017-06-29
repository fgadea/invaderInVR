using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverBulletInvader : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		//print ("Instancia de bala: " + gameObject.transform.position);
		GetComponent<Rigidbody>().velocity = -transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
