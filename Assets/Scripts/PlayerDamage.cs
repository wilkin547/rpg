using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageToDo = 10;

    public GameObject damageNumber;

    private void OnCollisionEnter2D(Collision2D collision) //Al chocar contra el enemigo...
    {
        if (collision.gameObject.tag.Equals("Player")) //Si lo que choca es el player...
        {
            CharacterStats stats = collision.gameObject.GetComponent<CharacterStats>(); //Obtiene los stats del player
            int totalDamage = damageToDo - stats.defenseLevels[stats.currentLevel]; //Indica que el damageToDo sera ahora totalDamage menos la defenza del player en su nivel actual segun sus stats
            if (totalDamage <= 0) //Si el resultado es menor o igual a 0
            {
                totalDamage = 1; //El minimo de daño sera 1, si no, si fuera 0, seria invulnerable
            }

            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage); //Hace daño al player cuando choca con el

            //Muestra el daño del enemigo al player, usa el mismo codigo que en WeaponDamage cuando el player hace daño al enemigo
            var clone = Instantiate(damageNumber, collision.gameObject.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
        }
    }
}