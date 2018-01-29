using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class ControllerMinigame : MonoBehaviour {
   
	public GameObject[] switches;
	public GameObject[] luces;
	public GameObject[] botones;
	public GameObject manager;
	GameManagerMini opcionesManager;

	Material prueba;
	public int activo = 0;
	int[] clave = {-1,-1,-1,-1};
	int[] pass = {0,3,1,2};
	public Text txtTimer;
    Coroutine crtCounter;
	public int counter = 30;
	int valor = 0;
	// Use this for initialization
	void Start () {
		opcionesManager = manager.GetComponent<GameManagerMini>();
		transform.position = new Vector3(switches[activo].transform.position.x,switches[activo].transform.position.y,transform.position.z);
		crtCounter = StartCoroutine(crtCounterDown());
		Instantiate(botones[1], switches[valor].transform.position + Vector3.forward*-0.1f, switches[valor].transform.rotation).name = "On" + valor;
		for(valor = 1; valor < 4; valor++){
			Instantiate(botones[0], switches[valor].transform.position + Vector3.forward*-0.1f, switches[valor].transform.rotation).name = "Off" + valor;
		}
		valor = 0;
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
			Destroy(GameObject.Find("Off" + activo));
			Instantiate(botones[1], switches[activo].transform.position + Vector3.forward*-0.1f, switches[activo].transform.rotation).name = "On" + activo;
		}
		
		
		if(Input.GetKeyDown(KeyCode.Space)){
			luces[activo].GetComponent<Light>().enabled = true;
			bool x = false;
			foreach(int i in clave){
				x = (i == activo)?true:x;
			}
			if(!x){
				clave[valor++] = activo;
			}
		}
		int encendidos = 0;
		foreach(GameObject luz in luces){
			if(luz.GetComponent<Light>().isActiveAndEnabled){
				encendidos++;
			}
		}
		if(encendidos == 4){
			bool prueba = true;
			for(int i = 0; i < 4; i++){
				if(clave[i] != pass[i]){
					prueba = false;
				}
			}
			claves(prueba);
		}
		transform.Translate(switches[activo].transform.position - transform.position);
	}
	
	public void claves(bool valort){
		foreach(GameObject luz in luces){
			luz.GetComponent<Light>().enabled = valort;
		}
		if(valort){
			opcionesManager.WinGame();
		}else{
			for(int i = 0; i < 4; i++){
				clave[i]= -1;
			}
			valor = 0;
		}
		this.GetComponent<ControllerMinigame>().enabled = !valort;
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
                opcionesManager.EndGame();
				break;
            }
        }
    }
}
