using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody2D npcRigidBody;

    public bool isWalking;

    public float walkTime = 1.5f;
    private float walkCounter;

    public float stopTime = 3.0f;
    private float stopCounter;

    //Direcciones en las que caminara el npc
    private Vector2[] walkingDirection =
    {
        new Vector2(1, 0),
        new Vector2(0, 1),
        new Vector2(-1, 0),
        new Vector2(0, -1)
    };

    private int currentDirection; //Variable donde se guardara en que direccion va el npc actualmente

    public BoxCollider2D villagerZone; //Referencia en el editor el area en la que se movera el npc

    void Start()
    {
        npcRigidBody = GetComponent<Rigidbody2D>();
        walkCounter = walkTime;
        stopCounter = stopTime;
    }
    
    void Update()
    {
        if (isWalking) //Si isWalking es verdadero, es por que la funcion StartWalking y sus parametros esta activa, y con ellos...
        {
            if (villagerZone != null) //Si villagerZone es diferente de null, o sea, que si tiene un game object referenciado
            {
                this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, villagerZone.bounds.min.x, villagerZone.bounds.max.x), Mathf.Clamp(this.transform.position.y, villagerZone.bounds.min.y, villagerZone.bounds.max.y), this.transform.position.z); //El npc solo se movera dentro de los limites del villagerZone
            }

            npcRigidBody.velocity = walkingDirection[currentDirection] * speed; //El npc se movera en la direccion que se haya elejido en el currentDirection de la funcion StartWalking

            walkCounter -= Time.deltaTime; //El walkCounter se ira disminuyendo

            if (walkCounter < 0) //Y al llegar a 0 el npc se detendra
            {
                StopWalking();
            }
        }
        else //Si no, si isWalking es false es porque la funcion StopWalking y sus parametros esta activa, y con ellos...
        {
            npcRigidBody.velocity = Vector2.zero; //Por si acaso se repite este codigo para detener al npc aunque ya este en la funcion StopWalking

            stopCounter -= Time.deltaTime; //stopCounter se ira disminuyendo

            if (stopCounter < 0) //Y al llegar a 0 el npc empezara a caminar otra vez
            {
                StartWalking();
            }
        }
    }

    //Funcion para caminar
    private void StartWalking()
    {
        isWalking = true;
        currentDirection = Random.Range(0, 4); //Elije una de las 4 direcciones en la que caminara el npc
        walkCounter = walkTime;
    }

    //Funcion para detenerse
    private void StopWalking()
    {
        isWalking = false;
        stopCounter = stopTime;
        npcRigidBody.velocity = Vector2.zero; //Detiene al npc
    }
}