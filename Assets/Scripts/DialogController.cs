using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{

    public Text txtDialog;
    public GameObject imgObj;
    public int timeToDisappear = 0;
    public bool canAppear = true;


    public int[] dialogsToShowContinue = { };

    public string[] lstDialogs = {



        "¡Demonios, se ha ido la luz! ¡Como es posible que en empresas tan prominentes como Thunder PJ ocurran cosas asi! ",
        "¡Mi trabajo se ha estropeado! Algo debió haber pasado.",
        "Ire a buscar a Angus.",
"¿Donde esta Angus? el deberia estar solucionandolo.",
"Ya se, ire a buscarlo al area de fusibles, tal vez este ahi.",
"Vaya... hasta la cafetería 'tres tiempos' está cerrada.",


        "Algo huele raro, debo seguir adelante.",
        "Uniforme número “3561”… ¿Pero qué diablos ha pasado aquí?",
        "Tres veces indica el número tres, debería buscar algo relacionado a eso.",
        "Recuerdo haber visto esos números hace un momento. ¡Es cierto! ¡El uniforme chamuscado tenía los números “3561” inscritos en él! Recuerdo que Angus vestía ese uniforme. También recuerdo que su oficina era la 5.",
        "“Día 27/01/2018, hoy se ha sido asignado verificar el estado de la caja de electricidad. Se dice que ha estado inestable, pero de seguro es un problema menor.”",

        "¡Padre Santo! ¡Este lugar ha de estar embrujado!",
        "Debería avisarle a alguien… Pero quisiera cumplir con los anhelos de mi compañero primero. ¡Sí! ¡Yo he de desactivar ese Firewall! ¡He de mandarlo con su familia!",
        "Gracias, amigo. Eres, en verdad, una gran persona."
        };

    public IEnumerator ShowDialog()
    {
        if (canAppear)
        {
            if (dialogsToShowContinue.Length >= 1)
            {
                for (int i = 0; i < dialogsToShowContinue.Length; i++)
                {
                    imgObj.SetActive(true);
                    txtDialog.text = lstDialogs[dialogsToShowContinue[i]];
                    yield return new WaitForSeconds(timeToDisappear);
                    txtDialog.text = "";
                    imgObj.SetActive(false);
                    canAppear = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ShowDialog());
        }
    }


}
