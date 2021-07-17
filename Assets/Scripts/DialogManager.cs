using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Este script esta en el game object Dialog

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox; //Variable para referenciar la caja de dialogo
    public Text dialogText; //Variable para referenciar el componente texto de dialogBox
    public bool dialogActive;

    public string[] dialogLines; //Variable array donde se guardaran las lineas de dialogo que se pasen desde el NPCDialog por medio del parametro de ShowDialog(), ya que AQUI es donde se desarrollara toda la logica de ir mostrando las lineas de dialogo del npc
    public int currentDialogLine; //Linea de dialogo actual a mostrar

    private PlayerController playerController; //Referencia para obtener el PlayerController e indicarle que el player esta hablando

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogLine++;
        }

        //Cuando el numero de linea de dialogo actual sea mayor al tamaño del array de las lineas de dialogo, la caja de dialogo se desactivara, o sea, cuando ya se haya leido todo lo que tiene que decir el npc
        if (currentDialogLine >= dialogLines.Length)
        {
            dialogActive = false;
            dialogBox.SetActive(false);
            //currentDialogLine = 0; //Vuelve a 0 para que cada que se hable con el npc siempre empiece desde la primer linea
            playerController.playerTalking = false; //playerTalking vuelve a ser false para que el player pueda caminar otra vez
        }
        else
        {
            dialogText.text = dialogLines[currentDialogLine]; //Esta linea de codigo es la que se encarga de ir mostrando las lineas de dialogo mientras las haya, cada que currentDialogLine aumente al presionar espacio. Por medio de ella se muestra la primer linea del dialogo del npc
        }
    }

    //Esta funcion se llama desde el NPCDialog y por medio del funcionamiento de su codigo, o sea, al llamarla, funcionara el codigo de aqui, principalmente por medio de su parametro se rellena el string dialogLines
    public void ShowDialog(string[] dialogs)
    {
        dialogActive = true;
        dialogBox.SetActive(true);
        currentDialogLine = 0; //Es 0 para que el dialogo empiece desde la primer liea de dialogo
        dialogLines = dialogs;
        playerController.playerTalking = true; //playerTalking se vuelve true para que se detenga
    }
}