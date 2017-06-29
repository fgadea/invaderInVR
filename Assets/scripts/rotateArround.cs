using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateArround : MonoBehaviour {
	public Transform pointOfGravity;
	public GameObject obj;
	private float time;
	public int radius = 15;
	private float angle = (1 * Mathf.PI)/2;
	// Use this for initialization
	public static float velocity = 0.015f;
	void Awake(){
	}
	void Start () {
		StartCoroutine ("rutina");

	}
	
	// Update is called once per frame
	void Update () {
		if(obj.transform.position.y <= -35f){
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<EnemyHealth>().TakeDamage (0.4f);
			Destroy (obj);
		}
	}
	IEnumerator rutina(){
		angle += velocity;
		yield return new WaitForSeconds(0.033f);
		obj.transform.position = new Vector3(pointOfGravity.position.x + radius * Mathf.Cos (angle), obj.transform.position.y, pointOfGravity.position.z + radius * Mathf.Sin (angle));
		if(angle >= Mathf.PI * 2){
			obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y-5f, obj.transform.position.z);
			angle = 0f;
		}
		obj.transform.LookAt (pointOfGravity);
		obj.transform.eulerAngles += new Vector3(obj.transform.eulerAngles.x * -2,180f,0f);
		yield return StartCoroutine(rutina());
	}

}
