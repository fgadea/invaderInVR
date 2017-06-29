using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//using TMPro;

public class vidaInvader1 : MonoBehaviour {
	public Color okLife;
	public Color mediumLife;
	public Color criticLife;
	public Color[] colors = new Color[7];
	public GameObject invader;
	public GameObject padreInvader;
	public GameObject player;
	public Canvas life;
	public bool isLived = true;
	public Transform Marciano;
	public rotateArround script_rotateArround;
	//public SpriteRenderer indicator;
	private TextMesh numberOfPoints;
	private SpriteRenderer bar;

	private controlDisparoInvader disparar_invader;
	private Animator animator;
	private bool timeToDead = false;
	private puntosScript script_numberOfPoints;
	// Use this for initialization
	void Start () {
		bar = invader.GetComponentInChildren<SpriteRenderer> ();
		bar.color = okLife;
		bar.transform.localScale = new Vector3(2f,1f,1f); 
		GameObject pts = GameObject.FindWithTag ("puntos");
		numberOfPoints = pts.GetComponent<TextMesh> ();/*GetComponent (FindObjectOfType<TextMesh> ());*/
		animator = GetComponent<Animator> ();
		disparar_invader = GetComponentInChildren<controlDisparoInvader> ();
		script_numberOfPoints = numberOfPoints.GetComponent<puntosScript> ();
		int c = Random.Range (0, 7);
		GetComponentInChildren<MeshRenderer> ().material.color = colors [c];
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setLife(float life){
		bar.transform.localScale -= new Vector3(life,0f,0f);
		//print ("Voy a sumar y los puntos antes son: " + script_numberOfPoints.getPuntos());
		script_numberOfPoints.sumarPuntos (20);
		//print ("He sumado y ahora los puntos son: " + script_numberOfPoints.getPuntos());
		if (bar.transform.localScale.x <= 1.3f && bar.transform.localScale.x > 0.7f && bar.color != mediumLife)
			bar.color = mediumLife;
		if (bar.transform.localScale.x > 0.1f && bar.transform.localScale.x <= 0.7f && bar.color != criticLife)
			bar.color = criticLife;
		if (bar.transform.localScale.x <= 0.1f){
			if(timeToDead){
				isLived = false;
				script_numberOfPoints.sumarPuntos (50);
			} else{
				script_rotateArround.StopAllCoroutines ();
				script_rotateArround.enabled = false;
				animator.enabled = true;
				//transform.localPosition = Vector3.zero;
				//transform.localEulerAngles = new Vector3 (0,180,0);
				//Marciano.localPosition = Vector3.zero;
				//Marciano.localEulerAngles = Vector3.zero;
				//print ("Rotation Box:" + Marciano.localRotation);
				animator.SetTrigger ("start");
			}
		}
	}
	public bool isLife(){
		return isLived;
	}
	public void eventAnimation(){
		bar.transform.localScale = new Vector3(2f,1f,1f);
		bar.color = okLife;
		timeToDead = true;
		disparar_invader.enabled = true;
		invader.transform.LookAt (player.transform.position);
	}

}
