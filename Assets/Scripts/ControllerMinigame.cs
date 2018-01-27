using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerMinigame : MonoBehaviour {
   /*
    

    int counter = 30;
     */
	public GameObject[] switches;
	public GameObject[] luces;
	public int activo = 0;
	string clave;
	public Text txtTimer;
    Coroutine crtCounter;
	public int counter = 30;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(switches[activo].transform.position.x,switches[activo].transform.position.y,transform.position.z);
		crtCounter = StartCoroutine(crtCounterDown());
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			activo++;
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			activo--;
		}
		activo = Mathf.Clamp(activo,0,3);
		if(Input.GetKeyDown(KeyCode.Space)){
			luces[activo].GetComponent<Light>().enabled = true;
			clave += activo;
		}
		int encendidos = 0;
		foreach(GameObject luz in luces){
			if(luz.GetComponent<Light>().isActiveAndEnabled){
				encendidos++;
			}
		}
		if(encendidos == 4){
			if(clave.Equals("0312")){
				foreach(GameObject luz in luces){
					luz.GetComponent<Light>().enabled = true;
				}
				Debug.Log("Correcto");
				this.GetComponent<ControllerMinigame>().enabled = false;
			}else{
				foreach(GameObject luz in luces){
					luz.GetComponent<Light>().enabled = false;
				}
				clave = "";
			}
		}
		transform.Translate(switches[activo].transform.position - transform.position);
	}
	public IEnumerator crtCounterDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            counter--;
            txtTimer.text = counter.ToString();
            if (counter <= 0)
            {
                Debug.Log("Termino");
				break;
            }
        }
    }
}
