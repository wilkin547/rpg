using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script esta en el game object CameraLimits

[RequireComponent(typeof(BoxCollider2D))]
public class CameraLimits : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<CameraFollow>().ChangeLimits(GetComponent<BoxCollider2D>()); //Encuentra el script CameraFollow el cual es unico y esta en la main camera, llama a su funcion ChangeLimits, se le pasa por parametro el box collider 2d del propio game object CameraLimits y asi, la logica de limitacion de la camara en el update del script CameraFollow funcionara
    }
}