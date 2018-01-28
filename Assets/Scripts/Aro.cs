using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aro : MonoBehaviour {
	public float tiempo;
	Coroutine crt;
	// Use this for initialization
	void Start () {
		crt = StartCoroutine(Destruir());
	}
	
	private IEnumerator Destruir(){
		yield return new WaitForSeconds(tiempo);
		Destroy(this.gameObject);
	}

}
