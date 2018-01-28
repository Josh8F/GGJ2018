using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverImagen : MonoBehaviour
{
    public RawImage _rawImagen;
    public float _velocidad;

    void Start()
    {
        _rawImagen = GetComponent<RawImage>();
    }


    public void Update()
    {
        Rect currentUV = _rawImagen.uvRect;
        currentUV.x += Time.deltaTime * _velocidad;
        currentUV.y += Time.deltaTime * _velocidad;

        if (currentUV.x <= -1f || currentUV.x >= 1)
        {
            currentUV.x = 0f;
        }

        if (currentUV.y <= -1f || currentUV.y >= 1)
        {
            currentUV.y = 0f;
        }

        _rawImagen.uvRect = currentUV;
    }
}
