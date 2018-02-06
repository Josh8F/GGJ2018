using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{

    public string animationToPlay;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(PlayAnimation(other.gameObject));
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator PlayAnimation(GameObject go)
    {
        go.GetComponentInChildren<Animator>().SetBool(animationToPlay, true);
        yield return new WaitForSeconds(1.5f);
        go.GetComponentInChildren<Animator>().SetBool(animationToPlay, false);
    }
}
