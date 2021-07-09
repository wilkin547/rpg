using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damageToDo; //Cantidad de daño que hara el arma

    public GameObject hurtAnimation; //Animacion de daño
    public GameObject hurtAnimationOrigin; //Lugar donde aparecera la animacion de daño y el numero del daño
    public GameObject damageNumber; //Numero del daño

    private void OnTriggerEnter2D(Collider2D collision) //Cuando algo choca con el trigger...
    {
        if (collision.gameObject.tag.Equals("Enemy")) //... y, si es el enemigo...
        {
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damageToDo); //Le hara daño

            Instantiate(hurtAnimation, hurtAnimationOrigin.transform.position, hurtAnimationOrigin.transform.rotation); //La animacion de daño se instancia donde se indica, junto con su rotacion

            var clone = Instantiate(damageNumber, hurtAnimationOrigin.transform.position, Quaternion.Euler(Vector3.zero)); //El numero del daño se instancia en el mismo lugar, pero se especifica que su rotacion sera 0, porque el origen esta rotado 45°, y se guarda en una variable porque en la proxima linea de codigo se cambiara el numero a mostrar por default, por el daño que hace el arma
            clone.GetComponent<DamageNumber>().damagePoints = damageToDo; //Se reasigna el numero a mostrar por el daño que hace el arma
        }
    }
}