using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsManager : MonoBehaviour
{
    public Text gemsText; //Variable del texto de la cantidad de gemas en la UI
    public int currentGems; //Gemas actuales
    private const string gemskey = "CurrentGems"; //Llave para poder consultar y asignarle valor en las PlayerPrefs

    void Start()
    {
        if (PlayerPrefs.HasKey(gemskey)) //Si las PlayerPrefs tiene la key gemskey...
        {
            currentGems = PlayerPrefs.GetInt(gemskey); //El vaor de currentGems sera el asignado a la llave gemskey si existe el archivo de preferencias
        }
        else //Si no...
        {
            currentGems = 0; //No habran gemas(porque seria la primer partida)
            PlayerPrefs.SetInt(gemskey, 0); //Y se asigna a la key gemskey en las PlayerPrefs
        }
        gemsText.text = currentGems.ToString(); //Dependiendo del if de arriba, el valor de las currentGems se reflejara en el texto de la UI
    }
    
    //Funcion para sumar las gemas que se vallan recolectando al pasarle el parametro y ejecutar el codigo aqui
    public void AddGems(int gemsCollected)
    {
        currentGems += gemsCollected;
        PlayerPrefs.SetInt(gemskey, currentGems);
        gemsText.text = currentGems.ToString();
    }
}