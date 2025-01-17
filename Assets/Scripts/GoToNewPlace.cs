﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria para poder cambiar entre escenas

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName; //Nombre de la escena a cargar al entrar en la change zone

    public string goToPlaceName; //Nombre del spawn zone del lugar al que va a ir al entrar en la change zone

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<PlayerController>().nextPlaceName = goToPlaceName; //Indica que el nombre de la variable nextPlaceName del player controller es el de goToPlaceName de este script que se indica en el editor
            SceneManager.LoadScene(newPlaceName); //Carga la escena que se indique en el editor
        }
    }
}