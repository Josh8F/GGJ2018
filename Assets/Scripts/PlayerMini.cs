using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMini : MonoBehaviour {

	public GameObject GameManager;
	GameManagerMini manager;
	public bool activo = false, terminado = false;
	// Use this for initialization
	void Start () {
		manager = GameManager.GetComponent<GameManagerMini>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!activo){
			if(Input.GetKeyDown(KeyCode.Space)){
				activo = true;
				manager.StartGame();
			}
		}
		if(terminado){
			if(Input.GetKeyDown(KeyCode.Space)){
				manager.ChangeScene("Mini");
			}
		}
	}
}
