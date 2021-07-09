using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currentLevel; //Nivel actual
    public int currentExp; //Experiencia actual
    public int[] expToLevelUp; //Array de las cantidades de experiencia por nivel

    void Start()
    {
        
    }
    
    void Update()
    {
        //Si el nivel actual es mayor o igual que al tamaño del array de los niveles de experiencia, no hara nada
        if (currentLevel >= expToLevelUp.Length)
        {
            return;
        }

        //Si la experiencia actual es mayor o igual que la experiencia requerida en el nivel actual, subira un nivel
        if (currentExp >= expToLevelUp[currentLevel])
        {
            currentLevel++;
        }
    }

    //Añade experiencia a la actual
    public void AddExperience(int exp)
    {
        currentExp += exp;
    }
}