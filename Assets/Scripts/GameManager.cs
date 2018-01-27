using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		//G
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ControlPanel(GameObject obj){
        obj.SetActive(!obj.activeInHierarchy);
    }
}
