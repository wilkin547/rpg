using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target; //Variable en la que se referenciara el game object(objetivo/target) a seguir
    [SerializeField] private Vector3 targetPosition; //Variable que almacenara las coordenadas del target a seguir a travez de la variable target porque las obtendra constantemente en el Updata()
    [SerializeField] private float cameraSpeed = 4f; //Velocidad de la camara, es igual a la velocidad del player

    void Start()
    {
        
    }
    
    void Update()
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z); //Indica que las coordenadas de targetPosition seran las del target en "x" y "y", y en "z" las de la misma camara(por this. porque este script esta en la camara), que generalmente es -10

        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * cameraSpeed); //Indica que el movimiento de la camara(por this.) sera suavisado(por Lerp()(linear interpolation/interpolacion linear), sus parametros son: las coordenadas actuales de la camara, coordenadas a las que se movera, y el tiempo multiplicado por la velocidad de la camara
    }
}