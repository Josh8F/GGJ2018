using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    public GameObject itemToActive;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            itemToActive.SetActive(true);
            Destroy(GetComponent<ItemController>());
        }
    }
}
