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
    public NavMeshAgent agente;

    public GameManager _GameManager;
    public bool canMove = false;

    public Animator animator;

    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        agente = gameObject.GetComponent<NavMeshAgent>();

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
                    animator.SetBool("walk", true);
                    
                    agente.speed = velocidad;
                    agente.SetDestination(hit.point);
                }
            }
            if (Input.GetKeyDown("space"))
            {
                if (_GameManager.getInteraction())
                {
                    animator.SetBool("pickup", true);
                    //_GameManager.ChangeScene("Mini");

                }
            }
        }

    }

}
