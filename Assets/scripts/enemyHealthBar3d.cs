using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class enemyHealthBar3d : MonoBehaviour {
	public GameObject spaceShip;
	public GameObject bar;
	public Material[] materials = new Material[3];
	private TextMesh dialPuntos;
	private float damage;
	private puntosScript puntosPlayer;
	private Vector3 posIniBar;
	// Use this for initialization
	void Start () {
		bar.GetComponent<Renderer>().material = materials [0];
		posIniBar = bar.transform.localPosition;
		GameObject pts = GameObject.FindWithTag ("puntos");
		dialPuntos = pts.GetComponent<TextMesh> ();
		puntosPlayer = dialPuntos.GetComponent<puntosScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		new WaitForSeconds (1);
		/*if(bar.transform.localScale.y > 0){
			bar.transform.localScale -= new Vector3 (0f, 0.01f, 0f);
			bar.transform.localPosition -= new Vector3 (0f, 0.005f, 0f);
		}*/

	}
	public void TakeDamage(float DamagePerShoot){
		print ("Hola");
		bar.transform.localScale -= new Vector3 (0f, DamagePerShoot, 0f);
		bar.transform.localPosition -= new Vector3 (0f, 0.05f *(DamagePerShoot * 10), 0f);
		puntosPlayer.restarPuntos (10);
		if (bar.transform.localScale.y <= 0.7f && bar.transform.localScale.y > 0.5f)
			bar.GetComponent<Renderer>().material = materials[1];
		if (bar.transform.localScale.y <= 0.5f && bar.transform.localScale.y > 0.01f) {
			bar.GetComponent<Renderer>().material = materials[2];
		}
		if (bar.transform.localScale.y <= 0.01f) {
			//spaceShip.SetActive(false);
			puntosPlayer.sumarPuntos (10000);
		}
		/*if (BarDamage.fillAmount <= 0f) {
			BarDamage.fillAmount = 1f;
			BarDamage.material = progressOk;*/
	}
	public bool getDamage(){
		if (bar.transform.localScale.y <= 0.01f)
			return true;
		return false;
	}
	public void setFillLife(float fill){
		bar.transform.localScale += new Vector3 (0f, fill, 0);
		bar.transform.localPosition = posIniBar;
		bar.GetComponent<Renderer>().material = materials[0];
		puntosPlayer.resetCounter ();
	}
}
