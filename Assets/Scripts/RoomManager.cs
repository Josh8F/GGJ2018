using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{

    public string strPlace;
    public Text txtPlace;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            txtPlace.gameObject.SetActive(true);
            txtPlace.text = strPlace;
        }
    }

    void OnTriggerExit(Collider other)
    {
        txtPlace.text = "";
        txtPlace.gameObject.SetActive(false);
    }
}
