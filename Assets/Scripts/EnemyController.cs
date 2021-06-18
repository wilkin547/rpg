using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 1;
    private Rigidbody2D enemyRigidbody;

    private bool isWalking; //Como no se especifica su valor, es false por default

    public float timeToWalkAgain; //Tiempo que tardara en volver a caminar. Se asigna en el editor
    private float timeToWalkAgainCounter; //En esta variable se guardara el valor de timeToWalkAgain, esto porque en el codigo su valor se reducira a 0, y con timeToWalkAgain se reestablece de nuevo al valor asignado en el editor

    public float timeWalking; //Tiempo que tarda caminando. Se asigna en el editor
    private float timeWalkingCounter; //En esta variable se guardara el valor de timeWalking, esto porque en el codigo su valor se reducira a 0, y con timeWalking se reestablece de nuevo al valor asignado en el editor

    public Vector2 directionToWalk;

    private Animator enemyAnimator;
    private const string horizontal = "Horizontal"; //Guarda el input horizontal
    private const string vertical = "Vertical";

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>(); //Se encuentra y guarda el Rigidbody2D del enemigo
        enemyAnimator = GetComponent<Animator>();

        //Se indica el valor de los counters y se multiplican por un numero aleatorio para que cada enemigo se mueva diferente, 0.5 es 50% del tiempo asignado y 1.5 es 50% mas del tiempo asignado
        timeToWalkAgainCounter = timeToWalkAgain * Random.Range(0.5f, 1.5f);
        timeWalkingCounter = timeWalking * Random.Range(0.5f, 1.5f);
    }
    
    void Update()
    {
        if (isWalking) //Si isWalkign es true...
        {
            timeWalkingCounter -= Time.deltaTime; //... el valor de timeWalkingCounter se reducira en cada ciclo del if mientras isWalking sea true, restandole el tiempo del juego desde que inicio...
            enemyRigidbody.velocity = directionToWalk; //... el enemigo camina(la velodicad del enemigo sera la de directionToWalk, esto por medio del rigid body del enemigo)

            //El codigo de este if es para que el enemigo se detenga
            if (timeWalkingCounter < 0) //Si timeWalkingCounter es menor que 0(cuando se reduzca a menos que 0 por el codigo de arriba)...
            {
                isWalking = false; //... isWalking se hace false...
                timeToWalkAgainCounter = timeToWalkAgain; //... timeToWalkAgainCounter se reestablece al valor original asignado en el editor(esto porque se usa en el else del if padre de este if)...

                enemyRigidbody.velocity = Vector2.zero; //... y el enemigo se detiene
            }
        }
        else //Si no, si isWalking es false...
        {
            timeToWalkAgainCounter -= Time.deltaTime; //... el valor de timeToWalkAgainCounter se reducira en cada ciclo del else mientras isWalking sea false, restandole el tiempo del juego desde que inicio...

            //El codigo de este if es para preparar al enemigo para que camine
            if (timeToWalkAgainCounter < 0) //Si timeToWalkAgainCounter es menor que 0(cuando se reduzca a menos que 0 por el codigo de arriba)...
            {
                isWalking = true; //... isWalking se hace true...
                timeWalkingCounter = timeWalking; //... timeWalkingCounter se reestablece al valor original asignado en el editor(esto porque se usa en el if que esta en el if de este else)...

                directionToWalk = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * enemySpeed; //... y se indica que la direccion en la que el enemigo caminara sera random y se multiplica por su velocidad. NOTA: Es 2 y no 1 porque Random.Range nunca incluye el ultimo numero(si fuera 1), con 2 si lo incluye, por eso si fuera 1 solo se moveria a la izquierda y hacia abajo
            }

            //Como ahora isWalking es true otra vez, el if original se vuelve a ejecutar, y asi consecutivamente, esto hace que la direccion del movimiento del enemigo sea constante y random
        }

        enemyAnimator.SetFloat(horizontal, directionToWalk.x); //Indica que la animacion del enemigo en "x" sea la que corresponde segun la coordenada que se genero en directionToWalk
        enemyAnimator.SetFloat(vertical, directionToWalk.y);
    }
}