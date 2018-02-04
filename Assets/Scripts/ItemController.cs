using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    public GameObject itemToActive;
    public GameObject obstacleToDisable;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            itemToActive.SetActive(true);
            obstacleToDisable.SetActive(false);
            Destroy(GetComponent<ItemController>());
        }
    }
}
