using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class state : MonoBehaviour {
	public Image progressBar;
	public Material progressOk;
	public Material progressMedium;
	public Material progressCritic;

	// Use this for initialization
	void Start () {
		//StartCoroutine (MyCorroutine ());
	}
	
	// Update is called once per frame
	/*void Update () {
		for (float i = 1; i > 0; i -= 0.001f) {
			progressBar.fillAmount = i;
		}
	}*/

	IEnumerator MyCorroutine()
	{
		yield return new WaitForSeconds (0.5f);
		progressBar.fillAmount -= 0.1f;

		if (progressBar.fillAmount <= 0.5f && progressBar.fillAmount > 0.4f)
			progressBar.material = progressMedium;
		if (progressBar.fillAmount <= 0.3f && progressBar.fillAmount > 0.2f) {
			progressBar.material = progressCritic;
		}
		if (progressBar.fillAmount <= 0f) {
			progressBar.fillAmount = 1f;
			progressBar.material = progressOk;
		}
		StartCoroutine (MyCorroutine ());
	}


	
}
