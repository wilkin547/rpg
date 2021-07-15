using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damageToDo; //Cantidad de daño que hara el arma

    public GameObject hurtAnimation; //Animacion de daño
    public GameObject hurtAnimationOrigin; //Lugar donde aparecera la animacion de daño y el numero del daño
    public GameObject damageNumber; //Numero del daño

    //Por medio de esto se van a actualizar los puntos de daño que hara el arma
    private CharacterStats playerStats; //Es privado porque este game object es hijo del game object que tiene el Character Stats(el player)

    private void Start()
    {
        playerStats = GetComponentInParent<CharacterStats>(); //Busca el componente en el game object que contiene este game object
    }

    private void OnTriggerEnter2D(Collider2D collision) //Cuando algo choca con el trigger...
    {
        if (collision.gameObject.tag.Equals("Enemy")) //... y, si es el enemigo...
        {
            //totalDamage y el if que le sigue indicaran los puntos de daño que hara el arma al ir subiendo de nivel
            int totalDamage = damageToDo;
            if (playerStats != null)
            {
                totalDamage += playerStats.strengthLevels[playerStats.currentLevel];
            }

            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage); //Le hara daño

            Instantiate(hurtAnimation, hurtAnimationOrigin.transform.position, hurtAnimationOrigin.transform.rotation); //La animacion de daño se instancia donde se indica, junto con su rotacion

            var clone = Instantiate(damageNumber, hurtAnimationOrigin.transform.position, Quaternion.Euler(Vector3.zero)); //El numero del daño se instancia en el mismo lugar, pero se especifica que su rotacion sera 0, porque el origen esta rotado 45°, y se guarda en una variable porque en la proxima linea de codigo se cambiara el numero a mostrar por default, por el daño que hace el arma
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage; //Se reasigna el numero a mostrar por el daño que hace el arma
        }
    }
}