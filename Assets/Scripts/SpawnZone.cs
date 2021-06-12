using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTA: El codigo de esta escena se ejecuta automaticamente cuando la escena en la que esta se inicia, por eso la camara y el player se posicionan donde indica, sin que se llame el codigo por fuera

public class SpawnZone : MonoBehaviour
{
    private PlayerController thePlayer; //Variable donde se guardara el script del player
    private CameraFollow theCamera;
    public Vector2 facingDirection = Vector2.zero; //Variable para indicar desde el editor con coordenadas en que direccion mirara el player al entrar/salir de la casa, se inicia en 0(.zero)

    public string placeName; //Nombre del lugar en el que esta el spawn zone

    void Start() //Al iniciarse la escena...
    {
        thePlayer = FindObjectOfType<PlayerController>(); //Busca en la jerarquia el script PlayerController y lo guarda...
        theCamera = FindObjectOfType<CameraFollow>();

        if (thePlayer.nextPlaceName != placeName) //Si el nextPlaceName del player es diferente del placeName(en este script) del spawn zone donde deberia aparecer...
        {
            return; //... no hara nada y hasta aqui llegara la ejecucion del codigo del Start
        }
        //NOTA: Todo esto, desde la variable nextPlaceName en el player, la asignacion de su valor en el GoToNewPlace del change zone y comprobar esto, es para evitar que al iniciar el juego el player aparezca frente a la casa y no en el centro del mapa(porque como no viene de ningun lado el valor de la variable nextPlaceName es nulo), y para que el player entre y salga por el mismo lado con cada change zone con su respectivo spawn zone. Si el codigo y los nombres en el editor estan bien, este if no se cumplira y el codigo que sigue si se ejecutara

        thePlayer.transform.position = this.transform.position; //Indica que la posicion del player sera la de la spawn zone
        theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z); //La posiciond de la camara se indica con new Vector3 porque tiene profundidad y solo en la coordenada "z" se indica que sera la misma que de por si tenia la camara

        thePlayer.lastMovement = facingDirection; //Indica a que direccion mirara el player al entrar/salir de la casa por medio de lastMovement que usa las animaciones con coordenadas, por eso se indica con facingDirection, porque guarda coordenadas
    }
}