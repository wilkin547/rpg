using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))] //Reconfirma que el game object debe tener un circle collider 2d
public class QuestItem : MonoBehaviour
{
    public int questID;
    private QuestManager questManager;
    public string itemName;
    
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (questManager.quests[questID].gameObject.activeInHierarchy && !questManager.questsCompleted[questID]) //Si el quest de este item esta activo en la jerarquia y no ha sido completado...
            {
                questManager.itemCollected = itemName; //Su nombre se asignara a la variable correspondiente en el quest manager
                gameObject.SetActive(false); //Y el item se desactiva
            }
        }
    }
}