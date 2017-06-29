using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class gameMode : MonoBehaviour {

	//public variables
	public GameObject[] titles = new GameObject[2];
	public Image gazeReticle;

	//private variables
	private Ray ray;
	private RaycastHit hit;
	private Vector3 scaleGC = new Vector3(4f,4f,1f);
	private Vector3 scaleNGC = new Vector3 (2f, 2f, 1f);
	private GameObject lastGO;
	private float timer;


	// Use this for initialization
	void Start () {
		StartCoroutine ("gaze");
	}
	
	// Update is called once per frame
	void Update () {
		//timer
		timer += Time.deltaTime;

		//raycast from camera
		ray = GetComponent<Camera> ().ScreenPointToRay (new Vector3 (GetComponent<Camera> ().pixelWidth / 2, GetComponent<Camera> ().pixelHeight / 2, 10000000f));

		//if collision detected
		if(Physics.Raycast(ray, out hit)){
			if(hit.collider.transform.localScale == scaleGC || hit.collider.transform.localScale == scaleNGC){
				hit.collider.gameObject.transform.DOScale (hit.collider.transform.localScale + new Vector3(1f,1f,0f), .1f);
				lastGO = hit.collider.gameObject;

			}
			if (lastGO.CompareTag ("GameController")) {
				titles [0].SetActive (true);
				#if UNITY_EDITOR
				if(Input.GetKey(KeyCode.W) && timer >= 0.033f)
				#elif UNITY_ANDROID && !UNITY_EDITOR
				if(Input.anyKey && timer >= 0.033f)
				#endif
				{
					timer = 0;
					selectionObject.noGameController = false;
					SceneManager.LoadSceneAsync ("advertiment");
					SceneManager.UnloadSceneAsync ("preIntro");
				}
			}
			else if (lastGO.CompareTag ("noGameController")) {
				titles [1].SetActive (true);
			}
		}else {
			if(lastGO != null) {
				if (lastGO.transform.localScale != scaleGC || lastGO.transform.localScale != scaleNGC) {
					lastGO.transform.DOScale (lastGO.transform.localScale - new Vector3(1f,1f,0f), .1f);
					if (lastGO.CompareTag ("GameController"))
						titles [0].SetActive (false);
					else if (lastGO.CompareTag ("noGameController"))
						titles [1].SetActive (false);
					lastGO = null;
				}
			}
		}
	}

	//coroutine for noGameController mode
	IEnumerator gaze(){
		yield return new WaitForSeconds (0.033f);
		if(Physics.Raycast(ray, out hit)){
			if(hit.collider.CompareTag("noGameController"))
				gazeReticle.fillAmount += 0.01f;
		}if(!Physics.Raycast(ray)){
				gazeReticle.fillAmount = 0;
		}
		if (gazeReticle.fillAmount == 1) {
			selectionObject.noGameController = true;
			SceneManager.LoadSceneAsync ("advertiment");
			SceneManager.UnloadSceneAsync ("preIntro");
		}
		yield return StartCoroutine (gaze ());
	}
}
