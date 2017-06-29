using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour 
{
	public Transform lookAt = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (lookAt == null)
			return;

		transform.LookAt (lookAt);
		gameObject.transform.localEulerAngles += new Vector3(gameObject.transform.localEulerAngles.x * -2,180f,0f);
	}
}
