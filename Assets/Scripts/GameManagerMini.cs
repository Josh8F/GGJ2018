using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerMini : MonoBehaviour
{
    //public PlayerController _PlayerController;
    public GameObject _PlayerController;
    public Image inicio;
    public GameObject final;
    public Text textoFinal;
    public GameObject mensaje;

    Coroutine crt;
    int i = 0;
    public string[] letrasFinales;

    //public GameObject btnSpace;
    //public bool canInteract = false;

    void Start(){
        Cursor.visible = false;
    }
    public void ControlPanel(GameObject obj)
    {
        obj.SetActive(!obj.activeInHierarchy);
    }

    public void ChangeInteraction()
    {
       // canInteract = !canInteract;
        //btnSpace.SetActive(!btnSpace.activeInHierarchy);
    }
   /* public bool getInteraction()
    {
        return canInteract;
    }*/

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void StartGame()
    {   
        inicio.enabled = false;
        _PlayerController.GetComponent<ControllerMinigame>().enabled = true;       
    }

    public void EndGame()
    {
        final.SetActive(true);
        _PlayerController.GetComponent<ControllerMinigame>().enabled = false;
        _PlayerController.GetComponent<PlayerMini>().terminado = true;
    }
    public void WinGame()
    {   
        mensaje.SetActive(true);
        crt = StartCoroutine(escribir());
    }

    public IEnumerator escribir(){
        foreach(string texto in letrasFinales){
            for (int i = 0; i < texto.Length; i++){
                textoFinal.text += texto.Substring(i,1);
                yield return new WaitForSeconds(0.15f);
            }
            yield return new WaitForSeconds(0.6f);
            textoFinal.text = "";
        }
    }
}
