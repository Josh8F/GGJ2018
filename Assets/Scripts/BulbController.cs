using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbController : MonoBehaviour
{

    public GameObject light;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(crtLightBulb());
    }

    IEnumerator crtLightBulb()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.3f);
                light.SetActive(true);
                yield return new WaitForSeconds(0.3f);
                light.SetActive(false);

            }
            yield return new WaitForSeconds(2f);
        }
    }
}
