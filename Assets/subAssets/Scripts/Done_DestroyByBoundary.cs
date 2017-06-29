using UnityEngine;
using System.Collections;

/*Script for destroy objects that cross the limit*/
public class Done_DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		Destroy(other.gameObject);
	}
}