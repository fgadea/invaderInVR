using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContactFromPlayer : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private vidaInvader1 gameControllerInvader;
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.GetComponent <vidaInvader1> () != null)
			gameControllerInvader = other.GetComponent <vidaInvader1> ();
		else if(other.GetComponentInChildren<vidaInvader1>() != null){
			gameControllerInvader = other.GetComponentInChildren <vidaInvader1> ();
		}

		if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.CompareTag ("Shotable")) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			if (gameControllerInvader != null)
				gameControllerInvader.setLife (0.2f);
		}
		if (gameControllerInvader != null){
			if(!gameControllerInvader.isLife ()){
				Destroy (other.gameObject);
				Destroy (gameObject);
			}

		}
		else
			Debug.Log ("No se destrue el Obj");


	}
}
