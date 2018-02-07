using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	// Use this for initialization
	public GameObject llave;
	Animator animador;

	void Start(){
		animador = this.gameObject.GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			if(llave.activeSelf){
				animador.SetBool("Abrir", true);
			}else{
				//Mostrar mensaje de que necesita llave
				Debug.Log("no hay llave");
			}
		}
	}
}
