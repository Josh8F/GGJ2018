using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour {

	// Use this for initialization
	public GameObject llave, imgObj;
	public Text txtDialog;
	Animator animador;

	public float timeToDisappear = 0;

	void Start(){
		animador = this.gameObject.GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			if(llave != null){
				if(llave.activeSelf){
					animador.SetBool("Abrir", true);
					Destroy(this);
				}else{
					StartCoroutine(showDialog());
				}
			}else{
				animador.SetBool("Abrir", true);
				Destroy(this);
			}
			
		}
	}

	IEnumerator showDialog(){
		imgObj.SetActive(true);
        txtDialog.text = "Parece que está cerrado con llave.";
        yield return new WaitForSeconds(timeToDisappear);
        txtDialog.text = "";
        imgObj.SetActive(false);
	}
}
