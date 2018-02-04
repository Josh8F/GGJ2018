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
    Quaternion rotacion;


    public Animator animator;
    public AudioSource audioSource;


    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        agente = gameObject.GetComponent<NavMeshAgent>();
        rotacion.eulerAngles = new Vector3(90f, 0f, 0f);

    }
    void Update()
    {
        if (canMove)
        {
            if (Vector3.Distance(transform.position, agente.destination) <= 1f)
            {
                audioSource.Stop();
                animator.SetBool("walk", false);
            }


            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, distancia, interactuable))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(aro, hit.point + Vector3.up * alturaAro, rotacion);
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                    }
                    {
                        animator.SetBool("walk", true);

                        agente.speed = velocidad;
                        agente.SetDestination(hit.point);
                    }
                    animator.SetBool("walk", true);

                    agente.speed = velocidad;
                    agente.SetDestination(hit.point);
                }
                if (Input.GetKeyDown("space"))
                {
                    if (_GameManager.getInteraction())
                    {
                        animator.SetBool("pickup", true);
                        _GameManager.ChangeScene("Mini");

                    }
                }
                if (Input.GetKeyUp("space"))
                {
                    animator.SetBool("pickup", true);
                }
            }

        }
    }
}
