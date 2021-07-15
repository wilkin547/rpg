using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text; //Libreria para formatear el texto en tiempo real

public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text playerHealthBarText;
    public Text playerLevelText;

    public HealthManager playerHealthManager;
    public CharacterStats playerStats;
    
    void Update()
    {
        //Por si se sube de nivel
        playerHealthBar.maxValue = playerHealthManager.maxHealth; //El valor maximo del slider sera el de la vida maxima del player
        playerHealthBar.value = playerHealthManager.currentHealth; //El valor del slider sera el de la vida actual del player

        //Construccion del texto de la barra de vida del player
        StringBuilder barTextConstruction = new StringBuilder("HP: ");
        barTextConstruction.Append(playerHealthManager.currentHealth);
        barTextConstruction.Append("/");
        barTextConstruction.Append(playerHealthManager.maxHealth);
        playerHealthBarText.text = barTextConstruction.ToString(); //Indica que el texto que se construya sera el que aparecera en la barra de vida del player

        //Muestra en la UI el nivel y experiencia del player
        playerLevelText.text = "Level: " + playerStats.currentLevel + " (Exp: " + playerStats.currentExp + ")";
    }
}