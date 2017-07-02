using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class fistScript : MonoBehaviour {
	public Image background;
	public GameObject GOBackground;
	public GameObject firstAdv;
	public GameObject instanciator;
	private float timer = 0;
	// Use this for initialization
	void Start () {
		GOBackground.SetActive (true);
		firstAdv.SetActive (true);
		background.DOFade (.7f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 8) {
			GOBackground.SetActive (false);
			firstAdv.SetActive (false);
			instanciator.SetActive (true);
			GetComponent<fistScript> ().enabled = false;
		}
	}
}
