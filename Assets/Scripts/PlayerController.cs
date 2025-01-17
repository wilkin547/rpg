﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;

    private bool walking = false; //walking empieza en false porque el player esta inmovil al iniciar el juego
    public Vector2 lastMovement = Vector2.zero; //Variable 2d que se refiere a que el player esta inmovil(por .zero) al inicio, y el valor que se le dara sera en que direccion queda mirando al detenerse

    private const string horizontal = "Horizontal"; //Variable que guarda el input Horizontal de unity y al parecer tambien se usa al referirse al parametro Horizontal del Animator
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal"; //Variable que se refiere al parametro LastHorizontal del Animator
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";
    private const string attackingState = "Attacking";
    
    private Animator animator; //Variable para guardar el animator del player
    private Rigidbody2D playerRigidBody;
    
    public static bool playerCreated; //Variable booleana para verificar si el player ha sido creado o no. NOTA: Cualquier booleano que no se indique su valor al iniciar, sera false por default

    public string nextPlaceName; //Variable del nombre del proximo lugar al que va a ir el player al entrar en la change zone. Se asigna desde el editor en el script GoToNewPlace de la change zone

    private bool attacking = false;
    public float attackTime;
    private float attackTimeCounter;

    public bool playerTalking; //Booleano para indicar si el player esta hablando o no

    private Vector2 facingDirectionAtStart = new Vector2(0, -1);

    private SFXManager sfxManager;

    void Start()
    {
        animator = GetComponent<Animator>(); //Obtencion del animator del player
        playerRigidBody = GetComponent<Rigidbody2D>();
        sfxManager = FindObjectOfType<SFXManager>();

        if (playerCreated == false) //Si playerCreated es false...
        {
            playerCreated = true; //... playerCreated se vuelve true...
            DontDestroyOnLoad(this.transform.gameObject); //... y con la funcion de unity DontDestroyOnLoad() el player(por this.) no se destruira al cargar una nueva escena, esto se activara porque al cargar una nueva escena vera aqui en el start que playerCreated es false y evitara que el player se destruya
        }
        else //Si no, si ya ha sido creado un player...
        {
            Destroy(gameObject); //... destruira cualquier otro que se cree despues
        }

        playerTalking = false; //Al inicio del juego es false porque no esta hablando con nadie

        lastMovement = facingDirectionAtStart;
    }
    
    void Update()
    {
        //Formula del movimiento: s = v * t; espacio a moverse = velocidad * tiempo

        //Si el player esta hablando, se detendra y lo demas del codigo no se ejecutara mientras playerTalking sea true
        if (playerTalking)
        {
            playerRigidBody.velocity = Vector2.zero;
            return;
        }

        walking = false; //Walking es false todo el timepo, a menos que se detecte movimiento

        if (Input.GetMouseButtonDown(0)) //Si se presiona el click izquierdo del mouse...
        {
            attacking = true; //attacking se vuelve true
            attackTimeCounter = attackTime; //attackTimeCounter valdra lo que se halla indicado en attackTime desde el editor
            playerRigidBody.velocity = Vector2.zero; //El player se detendra si se estaba moviendo
            animator.SetBool(attackingState, true); //Y se reproducira la animacion de ataque
            sfxManager.playerAttack.Play();
        }

        if (attacking) //Si attacking es true...
        {
            attackTimeCounter -= Time.deltaTime; //El contador del tiempo que dura el ataque se ira reduciendo hasta llegar a 0 y...

            if (attackTimeCounter < 0) //Si attackTimeCounter es menor que 0...
            {
                attacking = false; //attacking se vuelve false
                animator.SetBool(attackingState, false); //Y la animacion de ataque se detiene
            }
        }
        else //Si no...
        {
            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f || Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f) //Si se detecta movimiento en cualquiera o ambos vectores...
            {
                walking = true; //walking se vuelve true

                lastMovement = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical)); //lastMovement sera el valor que obtenga del input de los vectores

                playerRigidBody.velocity = lastMovement.normalized * speed; //Y el movimiento del player sera lastMovement(el input de los vectores) normalizado, multiplicado por la velocidad
            }
        }

        if (walking == false) //Si walking es false...
        {
            playerRigidBody.velocity = Vector2.zero; //... el player se detendra por completo
        }

        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal)); //Indica al Animator que el valor del parametro Horizontal(por horizontal) sera el que se detecte en el input horizontal
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));

        animator.SetBool(walkingState, walking); //Indica al Animator si el parametro Walking es true o false segun la variable walking, la cual cambiara si se camina o no

        animator.SetFloat(lastHorizontal, lastMovement.x); //Indica al Animator que el valor del parametro LastHorizontal sera el de la variable lastMovement en su coordenada x
        animator.SetFloat(lastVertical, lastMovement.y);
    }
}