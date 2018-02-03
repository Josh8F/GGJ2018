using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyLight : MonoBehaviour
{


    Light light;
    public float minIntensity = 0.0f;
    public float maxIntensity = 1.5f;
    public float frequency = 0.01f;
    public float phase = 0.0f;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        float x = (Time.time + phase) * frequency;
        x = x - Mathf.Floor(x); // normalized value to 0..1
        light.intensity = maxIntensity * Mathf.Sin(2 * Mathf.PI * x) + minIntensity;

    }
}
