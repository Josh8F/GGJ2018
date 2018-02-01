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
    string[] letras = {"E","R","E","S", " ", "U","N"," ","B","U","E","N"," ", "A", "M", "I","G","O","."};

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
        while(true){
            if(i < letras.Length){
                textoFinal.text += letras[i];
                i++;
                yield return new WaitForSeconds(0.2f);
            }else{
                yield return new WaitForSeconds(2f);
                ChangeScene("credits");
            }
        }
    }
}
