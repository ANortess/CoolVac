using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad;

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
    }

    void ProcesarMovimiento()
    {
        //Lógica de movimiento
        float inputMovimientoX = Input.GetAxis("Horizontal");
        float inputMovimientoY = Input.GetAxis("Vertical");
        Rigidbody2D rigidbodyX = GetComponent<Rigidbody2D>();
        Rigidbody2D rigidbodyY = GetComponent<Rigidbody2D>();

        rigidbodyX.velocity = new Vector2(inputMovimientoX * velocidad, rigidbodyX.velocity.y);
        rigidbodyY.velocity = new Vector2(inputMovimientoY * velocidad, rigidbodyY.velocity.x);
    }
}
