using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class instaciator : MonoBehaviour {
	public GameObject spaceShip;
	public Transform posSpaceShip;
	public float esperaInicial = 1f;
	public float esperaEntreSpawn = 3f;
	public GameObject parent;

	private GameObject creation;

	//public TextMeshProUGUI puntos;
	public puntosScript puntosScript;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("routine", esperaInicial, esperaEntreSpawn);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void routine(){
		creation = Instantiate (spaceShip, posSpaceShip.position, posSpaceShip.rotation);
		creation.transform.SetParent (parent.transform);
		EnemyHealth setup = creation.GetComponent<EnemyHealth> ();
		//setup.Setup ();
		//spaceShip.transform.DOMoveZ (2.66f, 8).OnComplete (reestart);

	}
	/*public TextMeshProUGUI points(){
		return puntos;
	}*/

	public puntosScript getPuntosScript()
	{
		return puntosScript;
	}

}
