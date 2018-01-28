using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class ControllerMinigame : MonoBehaviour {
   
	public GameObject[] switches;
	public GameObject[] luces;
	public GameObject[] botones;

	Material prueba;
	public int activo = 0;
	string clave;
	public Text txtTimer;
    Coroutine crtCounter;
	public int counter = 30;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(switches[activo].transform.position.x,switches[activo].transform.position.y,transform.position.z);
		crtCounter = StartCoroutine(crtCounterDown());
		int valor = 0;
		Instantiate(botones[1], switches[valor].transform.position + Vector3.forward*-0.1f, switches[valor].transform.rotation).name = "On" + valor;
		for(valor = 1; valor < 4; valor++){
			Instantiate(botones[0], switches[valor].transform.position + Vector3.forward*-0.1f, switches[valor].transform.rotation).name = "Off" + valor;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			Destroy(GameObject.Find("On"+activo));
			Instantiate(botones[0], switches[activo].transform.position + Vector3.forward*-0.1f, switches[activo].transform.rotation).name = "Off"+activo;
			activo++;
			activo = Mathf.Clamp(activo,0,3);
			Destroy(GameObject.Find("Off"+activo));
			Instantiate(botones[1], switches[activo].transform.position + Vector3.forward*-0.1f, switches[activo].transform.rotation).name = "On" + activo;
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			Destroy(GameObject.Find("On"+activo));
			Instantiate(botones[0], switches[activo].transform.position + Vector3.forward*-0.1f, switches[activo].transform.rotation).name = "Off"+activo;
			activo--;
			activo = Mathf.Clamp(activo,0,3);
			Destroy(GameObject.Find("Off"+activo));
			Instantiate(botones[1], switches[activo].transform.position + Vector3.forward*-0.1f, switches[activo].transform.rotation).name = "On" + activo;
		}
		
		
		if(Input.GetKeyDown(KeyCode.Space)){
			luces[activo].GetComponent<Light>().enabled = true;
			foreach(char texto in clave.ToCharArray()){
				if(!texto.Equals(clave)){
					clave+= activo;
				}
			}
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
