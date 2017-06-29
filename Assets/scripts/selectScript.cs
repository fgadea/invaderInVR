using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectScript : MonoBehaviour {
	public Image gazeReticle;
	public static bool croutine = false;
	private Ray ray;
	private RaycastHit hit;
	private GameObject lastGO;
	private Vector3 scale = Vector3.one;
	private float timer;
	private Scene scene;
	// Use this for initialization
	void Start () {
		//if no gameController
		if (croutine)
			StartCoroutine ("gaze");
		scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
		//timer
		timer += Time.deltaTime;

		//ray from camera
		ray = GetComponent<Camera> ().ScreenPointToRay (new Vector3 (GetComponent<Camera> ().pixelWidth / 2, GetComponent<Camera> ().pixelHeight / 2, 10000000f));

		//collision detect with raycast
		if(Physics.Raycast(ray, out hit)){
			//augmented the objects
			if(hit.collider.transform.localScale == scale){
				hit.collider.gameObject.transform.DOScale (scale + new Vector3(1f,1f,0f), .1f);
				lastGO = hit.collider.gameObject;

			}	//condicional compilations for inputs
				#if UNITY_EDITOR
				if(Input.GetKey(KeyCode.W) && timer >= 0.033f)
				#elif UNITY_ANDROID && !UNITY_EDITOR
				if(Input.anyKey && timer >= 0.033f)
				#endif
				//end cond compilations
				{
				//load the correct scene
					timer = 0;
					SceneManager.LoadScene ("intro");
				SceneManager.UnloadSceneAsync (scene.name);
				}
		}else {
			if(lastGO != null) {
				if (lastGO.transform.localScale != scale ) {
					lastGO.transform.DOScale (scale, .1f);
					lastGO = null;
				}
			}
		}
	}


	//coroutine for the game mode withut gameController
	IEnumerator gaze(){
		yield return new WaitForSeconds (0.033f);
		if(Physics.Raycast(ray, out hit)){
			if(hit.collider.CompareTag("back"))
				gazeReticle.fillAmount += 0.01f;
		}if(!Physics.Raycast(ray)){
			gazeReticle.fillAmount = 0;
		}
		if (gazeReticle.fillAmount == 1) {
			selectionObject.noGameController = true;
			SceneManager.LoadSceneAsync ("intro");
			SceneManager.UnloadSceneAsync (scene.name);
		}
		yield return StartCoroutine (gaze ());
	}
}
