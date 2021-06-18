using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth; //Vida maxima al inicio del juego
    [SerializeField] private int currentHealth; //Vida actual

    void Start()
    {
        currentHealth = maxHealth; //La vida actual al instanciarse el personaje sera la vida maxima al inicio del juego
    }
    
    void Update()
    {
        if (currentHealth <= 0) //Si la vida actual llega a 0...
        {
            gameObject.SetActive(false); //El personaje se desctiva
        }
    }

    public void DamageCharacter(int damage) //Funcion para dañar al personaje que recibe como parametro la cantidad de daño que recibira
    {
        currentHealth -= damage; //Resta esa cantidad a la vida actual
    }

    public void UpdateMaxHealth(int newMaxHealth) //Funcion que actualiza la cantidad de vida maxima recibiendo como parametro la cantidad que va a ser, esto cuando se suba de nivel
    {
        maxHealth = newMaxHealth; //La vida maxima tendra el valor de la nueva vida maxima
        currentHealth = maxHealth; //Y la vida actual tendra el valor de la vida maxima
    }
}