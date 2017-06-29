using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth2 : MonoBehaviour {
	public GameObject spaceShip;
	public Image BarDamage;
	public Material[] materials = new Material[3];

	private float damage;
	private puntosScript puntosPlayer;
	private instanciator2 puntos;
	// Use this for initialization
	void Awake(){

		//puntos = puntos.GetComponentsInParent<TextMeshProUGUI>();
	}
	public void Setup () {
		BarDamage.material = materials [0];
		puntos = GetComponentInParent<instanciator2> ();
		puntosPlayer = puntos.puntosScript;
		//puntos = GetComponentInParent<instaciator> ();
		//puntosPlayer = puntos.puntosScript;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void TakeDamage(float DamagePerShoot){
		print ("Hola");
		BarDamage.fillAmount -= DamagePerShoot;
		puntosPlayer.sumarPuntos (10);
		if (BarDamage.fillAmount <= 0.5f && BarDamage.fillAmount > 0.4f)
			BarDamage.material = materials[1];
		if (BarDamage.fillAmount <= 0.3f && BarDamage.fillAmount > 0.2f) {
			BarDamage.material = materials[2];
		}
		if (BarDamage.fillAmount <= 0.001f) {
			spaceShip.SetActive(false);
			puntosPlayer.sumarPuntos (30);
		}
		/*if (BarDamage.fillAmount <= 0f) {
			BarDamage.fillAmount = 1f;
			BarDamage.material = progressOk;*/
	}
	public bool getDamage(){
		if (BarDamage.fillAmount <= 0.01)
			return true;
		return false;
	}
	public void setFillLife(float fill){
		BarDamage.fillAmount = fill;
		puntosPlayer.resetCounter ();
	}
}
