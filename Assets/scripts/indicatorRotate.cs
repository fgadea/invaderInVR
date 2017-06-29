using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorRotate : MonoBehaviour {
	private RectTransform indicator;
	private GameObject cam;
	// Use this for initialization
	void Awake(){
		indicator = GetComponent<RectTransform> ();
		cam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		indicator.transform.eulerAngles = new Vector3 (indicator.transform.eulerAngles.x, indicator.transform.eulerAngles.y, cam.transform.eulerAngles.y * -1);
	}
}
