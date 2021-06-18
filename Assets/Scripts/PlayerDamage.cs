using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    /*
    //Comentado porque se modifico el OnCollisionEnter2D, para ejecutar el DamageCharacter del HealthManager

    public float timeToRevivePlayer; //Tiempo que tardara en revivir el player. Se asigna en el editor
    private float timeToRevivePlayerCounter; //En esta variable se guardara el valor de timeToRevivePlayer, esto porque en el codigo su valor se reducira a 0, y con timeToRevivePlayer se reestablece de nuevo al valor asignado en el editor
    private bool playerReviving;    

    private GameObject player; //Variable para referenciar al player en el editor
    */

    public int damageToDo = 10;

    /*
    //Comentado porque se modifico el OnCollisionEnter2D, para ejecutar el DamageCharacter del HealthManager

    void Update()
    {
        if (playerReviving)
        {
            timeToRevivePlayerCounter -= Time.deltaTime;

            if (timeToRevivePlayerCounter < 0)
            {
                playerReviving = false;
                player.SetActive(true);
            }
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D collision) //Al chocar contra el enemigo...
    {
        if (collision.gameObject.tag.Equals("Player")) //Si lo que choca es el player...
        {
            /*
            //Comentado porque se ejecuta el DamageCharacter del HealthManager

            collision.gameObject.SetActive(false); //El player se desactiva
            playerReviving = true; //playerReviving se vuelve true
            timeToRevivePlayerCounter = timeToRevivePlayer; //Se asigna el valor del counter
            player = collision.gameObject; //Se asigna que el valor de la variable player sera el game object del player(porque collision se refiere al player, que es lo que choco contra el enemigo), esto para evitar poner "player = GetComponent<GameObject>();" en el start de todas las instancias de los enemigos y ahorrar memoria porque asi solo se asignara su valor cuando el player choque con el enemigo
            */

            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damageToDo); //Hace daño al player cuando choca con el
        }
    }
}