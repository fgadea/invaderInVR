using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class puntosScript : MonoBehaviour {
	private TextMesh puntos;
	private int num = 0;
	// Use this for initialization
	void Awake(){
		num = 0;
		//puntos = GetComponent<TextMesh> ();
	}
	void Start () {
		puntos = GetComponent<TextMesh> ();

		//print ("Start de puntosTextMeshProUGUI con valor " + puntos.text + " en el dial y " + num + "en la variable \"num\"");
	}
	
	// Update is called once per frame
	void Update () {
		if (num >= 999999999)
			resetCounter ();
		//puntos.text = "" + num;
	}
	public void sumarPuntos(int puntos1){
		//new WaitForSeconds (0.1f);
		//print ("Puntos antes: " + num);
		num = num + puntos1;
		puntos.text = "" + num;
		//print ("Puntos después: " + num);
	}
	public void restarPuntos(int puntos1){
		//new WaitForSeconds (0.1f);
		num -= puntos1;
		puntos.text = "" + num;
	}
	public void resetCounter(){
		//new WaitForSeconds (0.1f);
		num = 0;
		puntos.text = "" + num;
	}
	public int getPuntos(){
		return num;
	}
}
