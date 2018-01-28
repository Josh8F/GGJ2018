using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Click : MonoBehaviour {

	Ray interaccion;
	RaycastHit hit;
	public LayerMask interactuable;
	public float distancia = 150;
	public GameObject personaje;
	public GameObject aro;
	NavMeshAgent agente;
	
	// Use this for initialization
	void Start () {
		agente = personaje.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, distancia, interactuable)){
			if(Input.GetMouseButtonDown(0)){
				Instantiate(aro, hit.point, Quaternion.identity);
				agente.SetDestination(hit.point);
			}
		}
	}
}
