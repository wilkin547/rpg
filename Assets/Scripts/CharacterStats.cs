using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currentLevel; //Nivel actual
    public int currentExp; //Experiencia actual
    public int[] expToLevelUp; //Array de las cantidades de experiencia por nivel

    public int[] hpLevels, strengthLevels, defenseLevels; //Arrays de los hp por nivel, fuerza del ataque por nivel y defenza por nivel

    //Por medio de esto se va a actualizar el hp del player
    private HealthManager playerHealthManager; //Es privado porque este script y el Health Manager estan en el player, por eso al inicializarlo en el Start() no hace falta referenciarlo en el editor, porque lo encuentra dentro del mismo game object

    void Start()
    {
        playerHealthManager = GetComponent<HealthManager>();
    }
    
    void Update()
    {
        //Si el nivel actual es mayor o igual que al tamaño del array de los niveles de experiencia, no hara nada
        if (currentLevel >= expToLevelUp.Length)
        {
            return;
        }

        //Si la experiencia actual es mayor o igual que la experiencia requerida en el nivel actual, subira un nivel y notificara al health manager la subida de hp
        if (currentExp >= expToLevelUp[currentLevel])
        {
            currentLevel++;
            playerHealthManager.UpdateMaxHealth(hpLevels[currentLevel]);
        }
    }

    //Añade experiencia a la actual
    public void AddExperience(int exp)
    {
        currentExp += exp;
    }
}