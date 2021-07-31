using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script se encarga de llamar la funcion que reproduce la pista de audio que se necesite segun la escena o zona en la que entre el player y le pasa el parametro que indica que pista es

public class NewTrackAudio : MonoBehaviour
{
    private AudioManager audioManager;
    public int newTrackID;
    public bool playOnStart;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (playOnStart) //Si al inicio(porque esto esta en Start), playOnStart es verdadero
        {
            audioManager.PlayNewTrack(newTrackID); //Reproducira la pista que se indique en el editor
        }
    }

    //Cuando el player entre en cierta zona
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioManager.PlayNewTrack(newTrackID); //Reproducira el numero de pista que se indique en el editor
            gameObject.SetActive(false); //Y desactivara este game object para que la pista no se reinicie cada que se entre en el trigger
        }
    }
}