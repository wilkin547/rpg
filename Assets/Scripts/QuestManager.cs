using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests; //Array de quest a hacer
    public bool[] questsCompleted; //Quests completados

    private DialogManager dialogManager;

    void Start()
    {
        questsCompleted = new bool[quests.Length]; //Indica que el tamaño del array de las ques completadas sera el del array del total de quests que hay
        dialogManager = FindObjectOfType<DialogManager>();
    }    

    //Muestra el texto del quest que se le pase por parametro
    public void ShowQuestText(string questText)
    {
        string[] dialogLine = new string[]
        {
            questText
        };

        dialogManager.ShowDialog(dialogLine); //El parametro que pide ShowDialog es un array de strings, pero el texto del quest es de un solo string, asi que para que funcione lo que se hace es conviertir el texto del quest en un array de un unico string(dialogLines), todo esto porque generalmente el texto al iniciar un quest no es de tantas lineas
    }
}