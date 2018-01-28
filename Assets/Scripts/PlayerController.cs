using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Ray interaccion;
    RaycastHit hit;
    public LayerMask interactuable;
    public float distancia = 150;
    public float velocidad = 10f;
    public float alturaAro;
    public NavMeshAgent agente;
    public GameObject aro;
    public GameManager _GameManager;
    public bool canMove = false;
<<<<<<< HEAD
    Quaternion rotacion;


    public Animator animator;
=======

    public Animator animator;

>>>>>>> b38711622e061c7f453e433ffe27c8ff1c8be52e
    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        agente = gameObject.GetComponent<NavMeshAgent>();
<<<<<<< HEAD
        rotacion.eulerAngles = new Vector3(90f, 0f, 0f);
=======
>>>>>>> b38711622e061c7f453e433ffe27c8ff1c8be52e

    }
    void Update()
    {
        if (canMove)
        {
            if (Vector3.Distance(transform.position, agente.destination) <= 1f)
            {
                animator.SetBool("walk", false);
            }
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, distancia, interactuable))
            {
                if (Input.GetMouseButtonDown(0))
                {
<<<<<<< HEAD
                    Instantiate(aro, hit.point + Vector3.up * alturaAro, rotacion);

                    {
                        animator.SetBool("walk", true);

                        agente.speed = velocidad;
                        agente.SetDestination(hit.point);
                    }
=======
                    animator.SetBool("walk", true);
                    
                    agente.speed = velocidad;
                    agente.SetDestination(hit.point);
>>>>>>> b38711622e061c7f453e433ffe27c8ff1c8be52e
                }
                if (Input.GetKeyDown("space"))
                {
<<<<<<< HEAD
                    if (_GameManager.getInteraction())
                    {
                        animator.SetBool("pickup", true);
                        //_GameManager.ChangeScene("Mini");

                    }
=======
                    animator.SetBool("pickup", true);
                    //_GameManager.ChangeScene("Mini");

>>>>>>> b38711622e061c7f453e433ffe27c8ff1c8be52e
                }
            }

        }
    }
}
