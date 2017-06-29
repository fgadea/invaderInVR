using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlDisparo : MonoBehaviour {
	public GameObject disparo;
	public Transform posDisparo;
	public float esperaPpal;
	public float frecuanciaDisparos;

	private float timer;
	private float effectsBetweenBullets = 0.3f;

	private AudioSource audioSource;

	void Awake(){
		audioSource = GetComponent<AudioSource> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		#if UNITY_EDITOR
		if(Input.GetKey("w") && timer >= frecuanciaDisparos){
			shoot ();
		}
		#endif
		#if UNITY_ANDROID && !UNITY_EDITOR
		if(Input.anyKey && timer >= frecuanciaDisparos){
			shoot ();
		}
		#endif
		if(timer >= frecuanciaDisparos * effectsBetweenBullets){
			dissableEffects ();

		}
	}
	void dissableEffects(){
		
	}
	void shoot(){
		timer = 0f;
		Instantiate (disparo, posDisparo.position, posDisparo.rotation);
		audioSource.Play();
	}
}
