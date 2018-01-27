using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

	Ray interaccion;
	RaycastHit hit;
	public LayerMask interactuable;
	public float distancia = 150;
	int valor = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, distancia, interactuable)){
			if(Input.GetMouseButtonDown(0)){
				Debug.Log("Interactuable" + ++valor);
			}
		}
	}
}
