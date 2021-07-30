using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script esta en el game object AudioManager para que se acceda mas facil a las pistas de audio

public class AudioVolumeManager : MonoBehaviour
{
    private AudioVolumeController[] audios; //Array de todos los audios que tengan el componente AudioVolumeController
    public float maxVolumeLevel; //Volumen maximo, se asigna desde el editor
    public float currentVolumeLevel; //Volumen actual, se asigna desde el editor
    
    void Start()
    {
        audios = FindObjectsOfType<AudioVolumeController>(); //FindObjectsOfType es para localizar varios componentes del mismo tipo, porque es en plural por la "s" al final de Objects, esto cuando la variable donde se van a guardar es un array
        ChangeGlobalAudioVolume(); //Se llama en el Start para que desde el inicio del jueo aplique el volumen que se indique desde el editor
    }

    void Update()
    {
        ChangeGlobalAudioVolume(); //Y se llama en el Update para que el volumen del audio se pueda modificar mientras el juego esta en curso
    }

    //Funcion que cambia el volumen global de los audios del juego
    public void ChangeGlobalAudioVolume()
    {
        if (currentVolumeLevel >= maxVolumeLevel) //Si el volumen actual es mas que el volumen maximo...
        {
            currentVolumeLevel = maxVolumeLevel; //El volumen actual sera igual al maximo, o sea, no se pasara
        }

        foreach (AudioVolumeController avc in audios) //Para cada elemento en audios...
        {
            avc.SetAudioVolume(currentVolumeLevel); //Se llama la funcion SetAudioVolume de cada elemento y se le pasa por parametro el volumen actual
        }
    }
}