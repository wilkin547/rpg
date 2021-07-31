using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script esta en el game object AudioManager y tiene la funcion que se encarga de reproducir la pista de audio que se necesite segun la escena o zona, la cual es PlayNewTrack

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioTracks;
    public int currentTrack;
    public bool audioCanBePlayed;
    
    void Update()
    {
        if (audioCanBePlayed) //Si el audio puede ser reproducido...
        {
            if (!audioTracks[currentTrack].isPlaying) //Pero si la pista actual no se esta reproduciendo... NOTA: isPlaying es una variable booleana propia de la clase AudioSource
            {
                audioTracks[currentTrack].Play(); //Entonces la reproducira
            }
        }
    }

    //Funcion que reproduce una nueva pista de audio
    public void PlayNewTrack(int newTrack)
    {
        audioTracks[currentTrack].Stop(); //Se detiene la pista actual
        currentTrack = newTrack; //Se asigna la nueva pista a reproducir
        audioTracks[currentTrack].Play(); //Y se reproduce
    }
}