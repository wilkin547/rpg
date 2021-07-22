using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    private QuestManager questManager;

    public string startText, completedText; //Textos a mostrar al iniciar y al completar el quest    

    //Funcion que inicia el quest
    public void StartQuest()
    {
        questManager = FindObjectOfType<QuestManager>();
        questManager.ShowQuestText(startText); //Notifica al quest manager que muestre el texto de inicio del quest
    }

    //Funcion que indicara que esta quest esta completada
    public void CompleteQuest()
    {
        questManager.ShowQuestText(completedText); //Notifica al quest manager que muestre el texto de que se completo el quest
        questManager.questsCompleted[questID] = true; //Indica que la quest en la posicion de su ID se completo
        gameObject.SetActive(false); //Desactiva la quest, si no se escribe esta linea de codigo, la quest se podra repetir
    }
}