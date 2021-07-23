using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] //Reconfirma que el game object debe tener un box collider 2d
public class QuestTrigger : MonoBehaviour
{
    private QuestManager questManager;
    public int questID;
    public bool startPoint, endPoint; //Booleanos donde se indica si el trigger es el del inicio o el del final
    
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (!questManager.questsCompleted[questID]) //Si el quest actual no se ha completado... (esta linea es si el quest se va a hacer solo una vez, si se podra repetir entonces no se escribe)
            {
                if (startPoint && !questManager.quests[questID].gameObject.activeInHierarchy) //Si se entro al startPoint y el quest no se ha activado en la jerarquia...
                {
                    questManager.quests[questID].gameObject.SetActive(true); //El quest se activa en la jerarquia
                    questManager.quests[questID].StartQuest(); //Y el quest se inicia
                }

                if (endPoint && questManager.quests[questID].gameObject.activeInHierarchy) //Si se entro al endPoint y el quest esta activo en la jerarquia...
                {
                    questManager.quests[questID].CompleteQuest(); //Se finaliza el quest
                }
            }
        }
    }
}