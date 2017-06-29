using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
//using TMPro;

public class EnemyHealth : MonoBehaviour {

	//public variables
	public GameObject spaceShip;
	public Image BarDamage;
	public Image SubBar;
	public Image contBar;
	public Image scope;
	public Color[] color = new Color[3];
	public float frecuanciaDisparos;
	public AudioSource audioSource;
	public GameObject playerExplosion;
	public Image gazeReticle;
	public Image hearth1;
	public Image hearth2;
	public Image hearth3;
	public Image gOver;
	public Image win;
	//public TextMeshProUGUI dialPuntos;

	//private variables
	private float damage;
	private TextMesh dialPuntos;
	private puntosScript puntosPlayer;
	private RaycastHit hit;
	private Ray ray;
	private Color oColor;
	private Vector3 scale;
	private float timer;
	private vidaInvader1 gameControllerInvader;
	private bool noGameController = selectionObject.noGameController;

	public bool hearts = true;
	// Use this for initialization

	void Awake(){
		
		//puntos = puntos.GetComponentsInParent<TextMeshProUGUI>();
	}
	public void Start () {
		BarDamage.color = color [0];
		BarDamage.fillAmount = 1f;
		GameObject pts = GameObject.FindWithTag ("puntos");
		dialPuntos = pts.GetComponent<TextMesh> ();
		puntosPlayer = dialPuntos.GetComponent<puntosScript> ();
		oColor = scope.color;
		scale = scope.transform.localScale;
		if(noGameController)StartCoroutine ("gaze");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		ray = GetComponent<Camera> ().ScreenPointToRay (new Vector3 (GetComponent<Camera> ().pixelWidth / 2, GetComponent<Camera> ().pixelHeight / 2, 10000000f));

		
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.CompareTag("Shotable") && scope.transform.localScale == scale) {
				scope.color = Color.white;
				scope.transform.DOScale(scale + Vector3.one, .1f);

			}
			
		}else{
			if (scope.transform.localScale != scale) {
				scope.transform.DOScale(scale, .1f);
				scope.color = oColor;
				//new WaitWhile (() => scope.transform.localScale != scale);
			}
		}

	}
	void FixedUpdate()
	{	
		if(puntosPlayer.getPuntos() >= 10000){
			mWin ();
		}
	}
	bool isPlaying(){
		return audioSource.isPlaying;
	}
	public void TakeDamage(float DamagePerShoot){
		BarDamage.fillAmount -= DamagePerShoot;

		subBar (DamagePerShoot);
		puntosPlayer.restarPuntos (10);
		if (BarDamage.fillAmount <= 0.5f && BarDamage.fillAmount > 0.25f)
			BarDamage.color = color[1];
		if (BarDamage.fillAmount <= 0.25f && BarDamage.fillAmount > 0.13f) {
			BarDamage.color = color[2];
		}
		if (BarDamage.fillAmount <= 0.13f) {
			if (hearth1.enabled)
				hearth1.enabled = false;
			else if (hearth2.enabled)
				hearth2.enabled = false;
			else if (hearth3.enabled)
				hearth3.enabled = false;
			else {
				hearts = false;
				gameOver ();
			}
		}
	}
	private void gameOver(){
		GameObject[] i = GameObject.FindGameObjectsWithTag ("Shotable");
		for(int j = i.Length-1; j>0; j--){
			Destroy (i[j]);
		}
		gOver.enabled = true;
		gOver.DOFade (0f, 0f);
		gOver.DOFade (1f, 2f).OnComplete(() => {
			SceneManager.LoadSceneAsync ("intro");
			SceneManager.UnloadSceneAsync ("juego");
		});

	}
	private void mWin(){
		GameObject[] i = GameObject.FindGameObjectsWithTag ("Shotable");
		for(int j = i.Length-1; j>0; j--){
			Destroy (i[j]);
		}
		win.enabled = true;
		win.DOFade (0f, 0f);
		win.DOFade (1f, 2f).OnComplete(() => {
			SceneManager.LoadSceneAsync ("intro");
			SceneManager.UnloadSceneAsync ("juego");
		});
	}
	private void subBar (float last)
	{
		var start = SubBar.fillAmount;
		var end = BarDamage.fillAmount;
		DOVirtual.Float (start, end, 3f, x => SubBar.fillAmount = x);
	}

	public bool getDamage(){
		if (BarDamage.fillAmount <= 0.13 && hearts)
			return true;
		return false;
	}
	public void setFillLife(float fill){
		new WaitForSeconds (3f);
		BarDamage.fillAmount = fill;
		SubBar.fillAmount = fill;
		BarDamage.color = color [0];
		//puntosPlayer.resetCounter ();
	}
	IEnumerator gaze(){
		yield return new WaitForSeconds (0.033f);
		if(Physics.Raycast(ray, out hit)){
			gazeReticle.fillAmount += 0.1f;
		}if(!Physics.Raycast(ray,out hit)){
			gazeReticle.fillAmount = 0;
		}
		if (gazeReticle.fillAmount == 1) {
			GetComponent<shoot> ().withoutController = true;
		} else
			GetComponent<shoot> ().withoutController = false;
		yield return StartCoroutine (gaze ());
	}
}
