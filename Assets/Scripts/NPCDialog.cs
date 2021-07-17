using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public string[] dialogs; //Array de lineas de dialogo que dira el NPC
    private DialogManager dialogManager; //Variable donde se guardara el DialogManager
    private bool playerInTheZone;    

    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>(); //FindObjectOfType se usa para encontrar un game object/script que sea unico en todo el proyecto
    }

    void Update()
    {
        if (playerInTheZone && Input.GetKeyDown(KeyCode.Return)) //Si el player esta en la zona de dialogo del npc y se presiona enter...
        {
            dialogManager.ShowDialog(dialogs); //Se mostrara el dialogo del npc. NOTA: Esto solo activa la caja de dialogo y mostrara la primer linea

            if (gameObject.GetComponentInParent<NPCMovement>() != null) //Si el padre de este game object tiene el script NPCMovement...
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true; //La variable isTalking de ese script sera true, esto para que el npc deje de caminar al estar hablando
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInTheZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInTheZone = false;
        }
    }
}