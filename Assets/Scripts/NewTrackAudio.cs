using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script se encarga de reproducir una nueva pista de audio segun la escena o area en la que entre

public class NewTrackAudio : MonoBehaviour
{
    private AudioManager audioManager;
    public int newTrackID;
    public bool playOnStart;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (playOnStart) //Si al inicio(porque esto esta en start), playOnStart es verdadero
        {
            audioManager.PlayNewTrack(newTrackID); //Reproducira la pista que se indique en el editor
        }
    }

    //Cuando el player entre en cierta zona, reproducira la pista que se indique en el editor y desactivara este game object para que la pista no se reinicie cada que se entre en el
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioManager.PlayNewTrack(newTrackID);
            gameObject.SetActive(false);
        }
    }
}