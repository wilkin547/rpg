using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests; //Array de quest a hacer
    public bool[] questsCompleted; //Array de quests completados, lo cual se indicara con true o false en cada uno

    private DialogManager dialogManager;

    public string itemCollected; //Variable donde se guardara el nombre del item recolectado de la quest que lo requiera, se indica desde el script QuestItem

    public string enemyKilled; //Variable donde se guardara el nombre del enemigo derrotado de la quest que lo requiera, se indica desde el script HealthManager

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

        dialogManager.ShowDialog(dialogLine); //El parametro que pide ShowDialog es un array de strings, pero el texto del quest es de un solo string, asi que para que funcione lo que se hace es conviertir el texto del quest en un array de un unico string(dialogLines), todo esto porque generalmente el texto al iniciar un quest no tiene tantas lineas
    }
}