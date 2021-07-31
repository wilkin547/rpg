using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script va en cada uno de los audios a reproducir por escena o zona

public class AudioVolumeController : MonoBehaviour
{
    private AudioSource audioSource; //Componente audio source de la pista de audio
    private float currentAudioVolume; //Volumen actual del audio
    public float defaultAudioVolume; //Volumen default del audio, se asigna desde el editor
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Funcion para setear el nuevo volumen de audio desde el AudioVolumeManager
    public void SetAudioVolume(float newVolume)
    {
        if (audioSource == null) //Si por alguna razon audioSource no cargo el componente AudioSource(porque la pista es muy pesada tal vez)
        {
            audioSource = GetComponent<AudioSource>(); //Lo cargara
        }

        currentAudioVolume = defaultAudioVolume * newVolume; //El volumen actual sera el resultado del defaultAudioVolume por el newVolume
        audioSource.volume = currentAudioVolume; //Y el volumen actual se asigna al volumen del audio source
    }
}