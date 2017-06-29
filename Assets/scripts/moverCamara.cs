using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/* script for move the camera in the editor*/

public class moverCamara : MonoBehaviour {
	public GameObject camara;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void Update () {
		
		#if UNITY_EDITOR
		if(Input.GetKey(KeyCode.LeftCommand) && Input.GetKey(KeyCode.UpArrow))
			camara.transform.eulerAngles -= new Vector3(0f,0f,0.8f);
		else if(Input.GetKey(KeyCode.UpArrow))
		{
			camara.transform.eulerAngles -= new Vector3(0.8f,0f,0f);
		}
		if(Input.GetKey(KeyCode.LeftCommand) && Input.GetKey(KeyCode.DownArrow))
			camara.transform.eulerAngles -= new Vector3(0f,0f,-0.8f);
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			camara.transform.eulerAngles += new Vector3(0.8f,0f,0f);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			camara.transform.eulerAngles -= new Vector3(0f,0.8f,0f);
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			camara.transform.eulerAngles += new Vector3(0f,0.8f,0f);
		}
		#endif
	}
}
