using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraScript : MonoBehaviour {
	//public GameObject particles;
	public GameObject line;
	public float damagePerShot = 0.20f; //daño por tiro
	public float timeBetweenBullets = 0.15f; //tiempo entre tiros
	public float range = float.PositiveInfinity; //distancia del disparo
	public Camera camera;

	float timer; //tiempo para determinar cuando disparar
	Ray shootRay; //rayo que sale de la pistola
	RaycastHit shootHit;  //Raycast que da información de donde ha chocado
	int shootableMask; //mascara del jugador que solo tocará el raycast si es Shootable
	ParticleSystem gunParticles; //referente al sistema de particulas
	LineRenderer gunLine; //referente a la linea que se dibuja como "rayo"
	AudioSource gunAudio; //referente al audio de disparo
	//Light gunLight; //referente a la luz que se activará en cada disparo
	float effectsDisplayTime = 0.2f; //La proporción de timeBetweenBullets

	// Use this for initialization
	void Awake () {
		shootableMask = LayerMask.GetMask ("Shootable"); //crea plantilla mascara para plantilla shootable

		//seteo de referencias
		//gunParticles = particles.GetComponent<ParticleSystem> ();
		gunLine = line.GetComponent<LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		//gunLight = GetComponent<Light> ();


	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		//Si se presiona la tecla de disparo y es tiempo de disparar se dispara
		if(Input.anyKey && timer >= timeBetweenBullets){
			//disparamos
			Shoot();

		}
		if (timer >= timeBetweenBullets * effectsDisplayTime) {
			dissableEffects ();

		}
		
	}

	public void dissableEffects(){
		//desactivamos efectos
		gunLine.enabled = false;
		//gunLight.enabled = false;
	}
	void Shoot(){
		//reseteamos el tiempo
		timer = 0f;

		//Reproducimos el sonido de disparo
		//gunAudio.Play();

		//Activamos la luz
		//gunLight.enabled = true;

		//paramos y ponemos en marcha las particulas
		//gunParticles.Stop();
		//gunParticles.Play ();

		//activamos linea de disparo y seteamos
		gunLine.enabled = true;
		//gunLine.SetPosition (0, transform.position);
		//Llevamos el rayo al gameObject
		shootRay = camera.ScreenPointToRay(new Vector3(camera.pixelWidth/2, camera.pixelHeight/2, 0f));
		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			//buscamos el scritp de vida del enemigo
			EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth> ();
			//si tiene script...
			if (enemyHealth != null) {
				print("Antes  hacer daño");
				//enemyHealth.TakeDamage (damagePerShot);
			}
			//gunLine.SetPosition (1, shootHit.point);
		} else {
			print("Sin hacer daño");
			//gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}

		
	}

}
