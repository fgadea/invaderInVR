using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shoot : MonoBehaviour {
	private float timer;
	private Ray ray;
	private RaycastHit hit;
	public float frecuanciaDisparos;
	public GameObject playerExplosion;
	public bool withoutController = false;
	private AudioSource audioSource;
	private LineRenderer lRenderer;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		lRenderer = GetComponentInChildren<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		ray = GetComponent<Camera> ().ScreenPointToRay (new Vector3 (GetComponent<Camera> ().pixelWidth / 2, GetComponent<Camera> ().pixelHeight / 2, 10000000f));
		#if UNITY_EDITOR
		if ((Input.GetKey ("w") || withoutController) && timer >= frecuanciaDisparos) 
		#elif UNITY_ANDROID && !UNITY_EDITOR
		if ((Input.anyKey || withoutController) && timer >= frecuanciaDisparos)
		#endif
		{
			audioSource.Play ();
			lRenderer.enabled = true;
			lRenderer.SetPosition(0, transform.position);
			timer = 0f;
			if (Physics.Raycast (ray, out hit/*, 500f*/)) {
				lRenderer.SetPosition (1, hit.transform.position);
				if (hit.collider.CompareTag ("Shotable")) {
					if (!withoutController)
						hit.collider.GetComponentInChildren<vidaInvader1> ().setLife (0.4f);
					else
						hit.collider.GetComponentInChildren<vidaInvader1> ().setLife (0.2f);
					Instantiate (playerExplosion, hit.transform.position, hit.transform.rotation);
					if (!hit.collider.GetComponentInChildren<vidaInvader1> ().isLife ()) {
						Destroy (hit.collider.gameObject);
					}
				}else if(hit.collider.CompareTag("back")){
					SceneManager.LoadScene ("intro");
					SceneManager.UnloadSceneAsync ("juego");
				}else if(hit.collider.CompareTag("settings")){
					SceneManager.LoadScene ("settings");
					SceneManager.UnloadSceneAsync ("juego");
				}

			} else
				lRenderer.SetPosition (1, ray.origin + ray.direction * 36);
		} else if (lRenderer.enabled == true)
			lRenderer.enabled = false;
	}
}
