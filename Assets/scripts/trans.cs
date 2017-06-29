using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;


/* especific script for this scene
 * change transition between scenes*/
public class trans : MonoBehaviour {
	public Image transicion;
	float time;
	bool a = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(a)time += Time.deltaTime;
		transicion.DOFade (0f, 3f).OnComplete(setA);
		if (time > 2) {
			transicion.DOFade (2f, 4f).OnComplete (next);
		}
	}
	void next(){
		SceneManager.LoadScene ("intro");
		SceneManager.UnloadSceneAsync ("advertiment");
	}
	void setA(){ a = true;}
}
