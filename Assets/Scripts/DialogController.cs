using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{

    public Text txtDialog;
    public GameObject imgObj;
    public int dialogNumToShow = 0;
    public int timeToDisappear = 0;

    public string[] lstDialogs = {
        "¡Demonios! ¡En empresas tan prominentes no se debería ir la luz de esta forma! ¡Mi trabajo está ido! Algo debió haber pasado.",
        "Algo huele raro, debo seguir adelante.",
        "Uniforme número “3561”…-dijo consternado, Ryan-¿Pero qué diablos ha pasado aquí?",
        "Tres veces indica el número tres, debería buscar algo relacionado a eso.",
        "Recuerdo haber visto esos números hace un momento. ¡Es cierto! ¡El uniforme chamuscado tenía los números “3561” inscritos en él! Recuerdo que Angus vestía ese uniforme. También recuerdo que su oficina era la 5.",
        "“Día 27/01/2018, hoy se ha sido asignado verificar el estado de la caja de electricidad. Se dice que ha estado inestable, pero de seguro es un problema menor.”",
        "¡Padre Santo! ¡Este lugar ha de estar embrujado!",
        "Debería avisarle a alguien… Pero quisiera cumplir con los anhelos de mi compañero primero. ¡Sí! ¡Yo he de desactivar ese Firewall! ¡He de mandarlo con su familia!",
        "Gracias, amigo. Eres, en verdad, una gran persona."
        };

    public IEnumerator ShowDialog()
    {
        imgObj.SetActive(!imgObj.activeInHierarchy);
        txtDialog.text = lstDialogs[dialogNumToShow];
        yield return new WaitForSeconds(timeToDisappear);
        txtDialog.text = "";
		imgObj.SetActive(!imgObj.activeInHierarchy);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ShowDialog());
        }
    }
}
