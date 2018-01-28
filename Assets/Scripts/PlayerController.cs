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
    public NavMeshAgent agente;

    public GameManager _GameManager;
    public bool canMove = false;
    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        agente = gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (canMove)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, distancia, interactuable))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    agente.SetDestination(hit.point);
                }
            }
            if (Input.GetKeyDown("space"))
            {
                if (_GameManager.getInteraction())
                {
                    _GameManager.ChangeScene("Mini");
                }
            }
        }

    }

}
