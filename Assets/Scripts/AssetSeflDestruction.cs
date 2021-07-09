using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSeflDestruction : MonoBehaviour
{
    public float timeToDestroy;
    
    void Update()
    {
        timeToDestroy -= Time.deltaTime; //Va disminuyendo el tiempo

        if (timeToDestroy <= 0) //Si el tiempo es menor a 0...
        {
            Destroy(gameObject); //El asset se destruye
        }
    }
}