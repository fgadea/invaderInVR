using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class enterTheSelection : MonoBehaviour {

	//public variables
	public Image background;
	public GameObject goBackground;
	public GameObject wait;

	//static variables for game mode
	public static bool op = false;

	//private variables
	private Ray ray;
	private RaycastHit hit;
	private float timer;
	public bool withoutController;


	// Use this for initialization
	void Start () {
		withoutController = false;
	}

	// Update is called once per frame
	void Update () {
		//timer
		timer += Time.deltaTime;

		//ray from camera
		ray = GetComponent<Camera> ().ScreenPointToRay (new Vector3 (GetComponent<Camera> ().pixelWidth / 2, GetComponent<Camera> ().pixelHeight / 2, 10000000f));

		//input condicional compilations
		#if UNITY_EDITOR
		if(Input.GetKey("w") || withoutController)
		#elif UNITY_ANDROID && !UNITY_EDITOR
		if(Input.anyKey || withoutController)
		#endif
		//end conditional compilations

		{//if collision detected
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.CompareTag ("start")) {
					goBackground.SetActive (true);
					background.DOFade (0.5f, 0f);
					wait.SetActive (true);
					SceneManager.LoadScene ("juego");
					SceneManager.UnloadSceneAsync ("intro");
				}else if(hit.collider.CompareTag("settings")){
					goBackground.SetActive (true);
					background.DOFade (0.5f, 0f);
					wait.SetActive (true);
					SceneManager.LoadScene ("preIntro");
					SceneManager.UnloadSceneAsync ("intro");
				}else if(hit.collider.CompareTag("back")){
					Application.Quit ();
				}else if(hit.collider.CompareTag("info")){
					goBackground.SetActive (true);
					background.DOFade (0.5f, 0f);
					wait.SetActive (true);
					SceneManager.LoadScene ("info");
					SceneManager.UnloadSceneAsync ("intro");
					selectScript.croutine = withoutController;
				}else if(hit.collider.CompareTag("question")){
					goBackground.SetActive (true);
					background.DOFade (0.5f, 0f);
					wait.SetActive (true);
					SceneManager.LoadScene("howPlay");
					SceneManager.UnloadSceneAsync ("intro");
					selectScript.croutine = withoutController;
				}

			}
		}
	}
}
