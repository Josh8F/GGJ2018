using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{

    public string animationToPlay;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            other.gameObject.GetComponentInChildren<Animator>().SetBool(animationToPlay, true);


        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponentInChildren<Animator>().SetBool(animationToPlay, false);
            //Destroy(GetComponent<AnimationTrigger>());
        }

    }
}
