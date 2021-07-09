using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth; //Vida maxima al inicio del juego
    public int currentHealth; //Vida actual

    public bool flashActive; //Indicara si el flash esta activo o no
    public float flashDuration; //Duracion del flasheo
    private float flashDurationCounter; //Contador de la duracion del flasheo

    public int expToGive; //Experiencia a dar cuando el player mate al enemigo

    private SpriteRenderer characterRenderer;

    void Start()
    {
        currentHealth = maxHealth; //La vida actual al instanciarse el personaje sera la vida maxima al inicio del juego
        characterRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (currentHealth <= 0) //Si la vida actual llega a 0...
        {
            //Si este game object tiene la etiqueta enemigo, suma al player la experiencia que da el enemigo al ser derrotado
            if (gameObject.tag.Equals("Enemy"))
            {
                GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(expToGive);
            }

            gameObject.SetActive(false); //El personaje se desctiva
        }

        //Hace parpadear al player al recibir daño
        if (flashActive)
        {
            flashDurationCounter -= Time.deltaTime; //Va disminuyendo el tiempo del contador

            if (flashDurationCounter > flashDuration * 0.66f) //Si es mayor a 2 tercios del tiempo lo oculta
            {
                ToggleView(false);
            }
            else if (flashDurationCounter > flashDuration * 0.33f) //Si es mayor a 1 tercio del tiempo lo muestra
            {
                ToggleView(true);
            }
            else if (flashDurationCounter > 0) //Si es mayor a 0 lo oculta
            {
                ToggleView(false);
            }
            else //Si no, si es igual a 0 lo muestra y pone flashActive en false
            {
                ToggleView(true);
                flashActive = false;
            }
        }
    }

    //Funcion para dañar al personaje que recibe como parametro la cantidad de daño que recibira
    public void DamageCharacter(int damage)
    {
        currentHealth -= damage; //Resta esa cantidad a la vida actual
        
        if (flashDuration > 0) //Si la duracion del flash es mayor a 0
        {
            flashActive = true;
            flashDurationCounter = flashDuration; //El contador toma el valor de la duracion porque de el se ira descontando, no de la duracion
        }
    }

    public void UpdateMaxHealth(int newMaxHealth) //Funcion que actualiza la cantidad de vida maxima recibiendo como parametro la cantidad que va a ser, esto cuando se suba de nivel
    {
        maxHealth = newMaxHealth; //La vida maxima tendra el valor de la nueva vida maxima
        currentHealth = maxHealth; //Y la vida actual tendra el valor de la vida maxima
    }

    //Intercalara entre mostrar y no mostrar al player cuando recibe daño
    private void ToggleView(bool visible)
    {
        characterRenderer.color = new Color(characterRenderer.color.r, characterRenderer.color.g, characterRenderer.color.b, (visible? 1.0f : 0.0f)); //Los primeros tres valores indican que los colores rgb seran los mismos y el cuarto parametro es el alfa, checara(con ?) si la variable visible es verdadera, se mostrara el sprite del player(1.0), si no, si es falsa, no se mostrara(0.0)
    }
}