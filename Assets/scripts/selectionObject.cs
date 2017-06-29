using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class selectionObject : MonoBehaviour {
	//public variables
	public GameObject[] titles = new GameObject[4];
	public Image gazeReticle;

	//static variable for gameController or no
	public static bool noGameController = false;

	//private variables
	private float timer;
	private Ray ray;
	private RaycastHit hit;
	private Vector3 scale = Vector3.one;
	private GameObject lastGO;

	// Use this for initialization
	void Start () {
		gazeReticle.fillAmount = 0;

		//if no gameController
		if(noGameController)StartCoroutine ("gaze");
	}
	
	// Update is called once per frame
	void Update () {
		//timer
		timer += Time.deltaTime;

		//ray from camara in the reticle position
		ray = GetComponent<Camera> ().ScreenPointToRay (new Vector3 (GetComponent<Camera> ().pixelWidth / 2, GetComponent<Camera> ().pixelHeight / 2, 10000000f));

		//if ray collision
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.gameObject.transform.localScale == scale) {
				hit.collider.gameObject.transform.DOScale (scale + Vector3.one, .1f);
				lastGO = hit.collider.gameObject;
				if(lastGO.CompareTag("start")){
					titles [0].SetActive (true);
				}else if(lastGO.CompareTag("settings")){
					titles [1].SetActive (true);
				}else if(lastGO.CompareTag("back")){
					titles [2].SetActive (true);
				}else if(lastGO.CompareTag("info")){
					titles [3].SetActive (true);
				}
			}

		}else {
			if(lastGO != null) {
				if (lastGO.transform.localScale != scale) {
					lastGO.transform.DOScale (scale, .1f);
				}
				if(lastGO.CompareTag("start")){
					titles [0].SetActive (false);
				}else if(lastGO.CompareTag("settings")){
					titles [1].SetActive (false);
				}else if(lastGO.CompareTag("back")){
					titles [2].SetActive (false);
				}else if(lastGO.CompareTag("info")){
					titles [3].SetActive (false);
				}
			}
		}
	}

	//coroutine for noGameController mode
	IEnumerator gaze(){
		yield return new WaitForSeconds (0.033f);
		if(Physics.Raycast(ray, out hit)){
			gazeReticle.fillAmount += 0.02f;
		}if(!Physics.Raycast(ray,out hit)){
			gazeReticle.fillAmount = 0;
		}
		if (gazeReticle.fillAmount == 1) {
			GetComponent<enterTheSelection> ().withoutController = true;
		} else
			GetComponent<enterTheSelection> ().withoutController = false;
		yield return StartCoroutine (gaze ());
	}
}
