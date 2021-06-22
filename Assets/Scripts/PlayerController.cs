using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    private float currentSpeed;

    private bool walking = false; //Variable que se refiere al valor del bool Walking, parametro del Animator
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

    void Start()
    {
        animator = GetComponent<Animator>(); //Obtencion del animator del player
        playerRigidBody = GetComponent<Rigidbody2D>();

        if (playerCreated == false) //Si playerCreated es false...
        {
            playerCreated = true; //... playerCreated se vuelve true...
            DontDestroyOnLoad(this.transform.gameObject); //... y con la funcion de unity DontDestroyOnLoad() el player(por this.) no se destruira al cargar una nueva escena, esto se activara porque al cargar una nueva escena vera aqui en el start que playerCreated es false y evitara que el player se destruya
        }
        else //Si no, si ya ha sido creado un player...
        {
            Destroy(gameObject); //... destruira cualquier otro que se cree despues
        }
    }
    
    void Update()
    {
        //Formula del movimiento: s = v * t; espacio a moverse = velocidad * tiempo

        walking = false; //Walking es false todo el timepo, a menos que alguno o ambos de los siguientes ifs se este cumpliendo(porque esto esta en el Update), si no, volvera a ser false

        if (Input.GetMouseButtonDown(0)) //Si se presiona el click izquierdo del mouse...
        {
            attacking = true; //attacking se vuelve true
            attackTimeCounter = attackTime; //attackTimeCounter valdra lo que se halla indicado en attackTime desde el editor
            playerRigidBody.velocity = Vector2.zero; //El player se detendra
            animator.SetBool(attackingState, true); //Y se reproducira la animacion de ataque
        }

        if (attacking) //Si attacking es true...
        {
            attackTimeCounter -= Time.deltaTime; //El contador del tiempo de ataque se reduce hasta que llega a 0 y...

            if (attackTimeCounter < 0) //Si attackTimeCounter es menor que 0...
            {
                attacking = false; //attacking se vuelve false
                animator.SetBool(attackingState, false); //Y attacking en el animator se vuelve false
            }
        }
        else
        {
            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f) //Si el movimiento absoluto(por Math.Abs) en valor horizontal del input es mayor que 0.5(presion en el boton), o sea, si se detecta input de manera horizontal...
            {
                /*
                //NOTA: Este codigo se comenta porque se pasa de mover al player con coordenadas usando translate a moverlo usando las fisicas del motor con el rigid body
                this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, 0, 0)); //... mueve al player(por this., porque este script esta en el player) en horizontal...
                */

                playerRigidBody.velocity = new Vector2(Input.GetAxisRaw(horizontal) * currentSpeed, playerRigidBody.velocity.y); //Mueve al player en horizontal, es Vector2 porque el rigid body es Rigidbody2D, la coordenada en "x" sera la que detecte en el input horizontal, multiplicado por la velocidad, la de "y" no se indica por si tambien se esta moviendo en "y", o sea, en diagonal, todo esto con .velocity en playerRigidBody
                walking = true; //... walking se vuelve verdadero mientras el player se mueva...
                lastMovement = new Vector2(Input.GetAxisRaw(horizontal), 0); //... y guarda la direccion en la que el player se detiene
            }

            if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
            {
                //this.transform.Translate(new Vector3(0, Input.GetAxisRaw(vertical) * speed * Time.deltaTime, 0));

                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, Input.GetAxisRaw(vertical) * currentSpeed);
                walking = true;
                lastMovement = new Vector2(0, Input.GetAxisRaw(vertical));
            }

            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f && Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f) //Si detecta movimiento en ambos vectores, o sea, un momiviento vertical...
            {
                currentSpeed = speed / Mathf.Sqrt(2); //currectSpeed es igual a speed entre raiz cuadrada de 2, porque estara duplicada por ambos vectores
            }
            else //Si no, si solo hay movimiento en un vector...
            {
                currentSpeed = speed; //currentSpeed sera igual al speed original
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