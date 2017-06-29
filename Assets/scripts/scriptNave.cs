using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scriptNave : MonoBehaviour {
	public GameObject spaceShip;
	public GameObject line;
	public GameObject player;
	//public Camera camera;
	//public float velocidadDesplazamiento;
	public Vector3 initPos;

	Ray shootRay; //rayo que sale del enemigo
	RaycastHit shootHit;  //Raycast que da información de donde ha chocado
	float timer;

	void awake(){
		//spaceShip.transform.DOMove (player.transform.position,8).OnComplete(destroy);

		//jugador = LayerMask.GetMask ("jugador");
		//gunLine = line.GetComponent<LineRenderer> ();
	}
	
	void Start () {
		spaceShip.transform.DOMove (player.transform.position,10).OnComplete(destroy);
		//routine ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1;

		if(timer%2 <= 0){
			shoot ();
			//print (timer);
		}
		
	}
	void destroy(){
		Destroy (spaceShip);
	}
	public void dissableEffects(){
		//desactivamos efectos
		//gunLine.enabled = false;
		//gunLight.enabled = false;
	}
	void shoot(){
		
	}
}
