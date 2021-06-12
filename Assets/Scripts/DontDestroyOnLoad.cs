using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTA: Este script va en cualquier game object que no se deba destruir al cargar una nueva escena, lo cual se logra ademas de poner este script en ese game object, poniendo un codigo igual en el PlayerController junto con la variable playerCreated(bool), en el que se basara para no eliminar el game object

public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake() //Se usa Awake y no Start porque en el siempre se llaman primero las variables y referencias entre scripts. NOTA: Aclaro esto porque como en las demas escenas no hay player ni camara, si fuera Start al iniciar el juego detectara como que no hay camara y no se vera nada
    {
        if (PlayerController.playerCreated == false) //Cualquier game object que tenga este script vera que la variable playerCreated en el PlayerController es false, y en base a eso...
        {
            DontDestroyOnLoad(this.transform.gameObject); //... evitara que este game object sea destruido al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject);
        }
    }
}