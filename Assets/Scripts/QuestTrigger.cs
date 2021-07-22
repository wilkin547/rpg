using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] //Reconfirma que el game object tenga el componente box collider 2d
public class QuestTrigger : MonoBehaviour
{
    private QuestManager questManager;
    public int questID;
    public bool startPoint, endPoint; //Booleanos que indicaran si el trigger es el del inicio o el del final
    
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (!questManager.questsCompleted[questID])
            {
                if (startPoint && !questManager.quests[questID].gameObject.activeInHierarchy)
                {
                    questManager.quests[questID].gameObject.SetActive(true);
                    questManager.quests[questID].StartQuest();
                }

                if (endPoint && questManager.quests[questID].gameObject.activeInHierarchy)
                {
                    questManager.quests[questID].CompleteQuest();
                }
            }
        }
    }
}