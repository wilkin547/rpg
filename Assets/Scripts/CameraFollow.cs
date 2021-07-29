using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variables para el seguimiento de la camara
    [SerializeField] private GameObject target; //Variable en la que se referenciara el game object(objetivo/target) a seguir
    [SerializeField] private Vector3 targetPosition; //Variable que almacenara las coordenadas del target a seguir a travez de la variable target porque las obtendra constantemente en el Updata()
    [SerializeField] private float cameraSpeed = 4f; //Velocidad de la camara, es igual a la velocidad del player

    //Variables para limitar la camara
    private Camera mainCamera; //Camara principal
    private Vector3 minLimits, maxLimits; //Variables donde se guardaran las coordenadas de los limites minimos y maximos de la camara
    float halfWidth, halfHeight; //Variables donde se guardaran la mitad del ancho y alto de la camara
    
    void Update()
    {
        //Logica del seguimiento de la camara
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z); //Indica que las coordenadas de targetPosition seran las del target en "x" y "y", y en "z" las de la misma camara(por this. porque este script esta en la camara), que generalmente es -10
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * cameraSpeed); //Indica que el movimiento de la camara(por this.) sera suavisado(por Lerp(), que significa linear interpolation/interpolacion linear), sus parametros son: las coordenadas actuales de la camara, coordenadas a las que se movera, y el tiempo multiplicado por la velocidad de la camara

        //Logica de la limitacion de la camara
        float clampX = Mathf.Clamp(this.transform.position.x, minLimits.x + halfWidth, maxLimits.x - halfWidth); //halfWidth se suma a los minimos para que se recorra a la derecha, y se resta de los maximos para que se recorra a la izquierda, esto para que la camara no se salga de los bordes
        float clampY = Mathf.Clamp(this.transform.position.y, minLimits.y + halfHeight, maxLimits.y - halfHeight);
        this.transform.position = new Vector3(clampX, clampY, this.transform.position.z); //Esta linea de codigo es la que asigna los limites de la camara en "x", "y", y "z" queda igual
    }

    public void ChangeLimits(BoxCollider2D newCameraLimits) //El parametro se pasa desde el script CameraLimits, y asi, la logica de la limitacion de la camara en el update funciona
    {
        minLimits = newCameraLimits.bounds.min; //Guarda los limites minimos de las 3 coordenadas de los limites de la camara
        maxLimits = newCameraLimits.bounds.max;

        mainCamera = GetComponent<Camera>(); //GetComponent es para obtener un componente que esta en el mismo game object que este script, en este caso obtiene el componente camara

        halfHeight = mainCamera.orthographicSize; //Variable que guarda la mitad de la altura de la camara, a eso se refiere orthographicSize cuando esta es ortografica
        halfWidth = halfHeight / Screen.height * Screen.width; //Variable que guarda la mitad del ancho de la camara, se calcula, y Screen.height/widtg se refieren al alto y ancho de la ventana del juego
    }
}