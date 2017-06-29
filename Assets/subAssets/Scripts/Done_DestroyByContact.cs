using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private EnemyHealth gameController;

	void Start ()
	{
		/*GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("Shotable");
		if (gameControllerObject != null)
		{
			if (gameControllerObject.GetComponent <EnemyHealth> () != null)
				gameController = gameControllerObject.GetComponent <EnemyHealth> ();
			else if (gameControllerObject.GetComponent <vidaInvader1> () != null)
				gameControllerInvader = gameControllerObject.GetComponent <vidaInvader1> ();
				
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}*/
	}

	void OnTriggerEnter (Collider other)
	{
		//if(other.tag == "Player") print ("Posición de choque: " + other.transform.position);
		if (other.GetComponentInParent <EnemyHealth> () != null)
			gameController = other.GetComponentInParent <EnemyHealth> ();
		
		if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.CompareTag("Player"))
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			if (gameController != null)
				gameController.TakeDamage (0.08f);
			/*else
				Debug.Log ("No se aplica el daño");*/
		}
		
		//gameController.AddScore(scoreValue);
		if (gameController != null){
			if (gameController.getDamage ()) {
				gameController.setFillLife (1f);
				//Destroy (other.gameObject);
				Destroy (gameObject);
			}
		}
		/*else
			Debug.Log ("No se destrye el Obj");*/
	

	}

}