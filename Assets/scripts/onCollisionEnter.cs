using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class onCollisionEnter : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		gameObject.transform.DOScale(gameObject.transform.localScale +=Vector3.one, .2f);
		print ("hola");
	}
	/*void OnCollisionExit(Collision other){
		gameObject.transform.DOScale(gameObject.transform.localScale -=Vector3.one, .2f);
		print ("exit");
	}*/
}
