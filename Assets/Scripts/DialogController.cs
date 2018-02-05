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
        "¡Demonios, se ha ido la luz! ¡¿Cómo es posible que en empresas tan prominentes como Thunder PJ ocurran cosas asi?! ",
        "¡Mi trabajo se ha estropeado! Algo debió haber pasado.",
        "Ire a buscar a Angus.",

"¿Donde está Angus? Él deberia estar solucionándolo.",
"Ya sé, iré a buscarlo al área de fusibles, tal vez esté ahi.",

"Vaya... la cafetería tres tiempos está cerrada.",
"Solo un poco mas, ya estoy cerca de los fusibles.",

"¡Rayos! ¿¡Que ha pasado aquí!? ¿De quién esa ropa? ",
"Qué extraño... Por alguna razón esta bombilla brilla tres veces...",

"Uniforme número “3561”…",
"Espera... ¡ese es el uniforme de Ryan!",
"¿Pero qué diablos ha pasado aquí?",
"¿Ryan? Ire a su oficina, es la numero 5.",

"Se ha abierto la cafeteria. ¿Qué está pasando aquí?",


"El microondas esta encendido",
"Dice algo: 3561",
"¿Ryan? ¿Eres tú amigo?",
"Debo ir a su oficina.",


"Está cerrada, debo buscarla.",

"Al fin estoy en su oficina.",
"Su ordenador está encendido, le echaré un vistazo.",
"Recuerdo que una vez me dijo que su contraseña era 4123",


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
