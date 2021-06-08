using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    private const string horizontal = "Horizontal"; //Variable que guarda el input horizontal
    private const string vertical = "Vertical";

    void Start()
    {
        
    }
    
    void Update()
    {
        //Formula del movimiento: s = v*t: espacio a moverse = velocidad * tiempo

        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f) //Si el movimiento absoluto(por Math.Abs) en valor horizontal del input es mayor que 0.5(presion en el boton), o sea, si se detecta input de manera vertical...
        {
            this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, 0, 0)); //... mueve al player(por this, porque este script esta en el player) en horizontal
        }
        if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            this.transform.Translate(new Vector3(0, Input.GetAxisRaw(vertical) * speed * Time.deltaTime, 0));
        }
    }
}