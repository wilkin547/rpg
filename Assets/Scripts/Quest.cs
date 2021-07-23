using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    private QuestManager questManager;

    public string startText, completedText; //Textos a mostrar al iniciar y al completar el quest

    public bool needsItem; //Booleano con el que se indicara si el quest necesita un item para completarse
    public string itemNeededName; //Nombre del item que se necita, debe ser igual al itemName en el script QuestItem

    void Start()
    {
        //questManager = FindObjectOfType<QuestManager>();
    }

    void Update()
    {
        if (needsItem && questManager.itemCollected.Equals(itemNeededName))
        {
            questManager.itemCollected = null;
            CompleteQuest();
        }
    }

    //Funcion que inicia el quest
    public void StartQuest()
    {
        questManager = FindObjectOfType<QuestManager>(); //El quest manager se recupera aqui, al iniciar el quest, en lugar de en el start porque si no no funciona
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