using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPrueba : MonoBehaviour
{
    [Header("Animacion")]
    private Animator animator;
    private bool mirandoDerecha = true;
    public bool seguirAnim = true;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        GestionarMovimiento(horizontal);
    }
    void GestionarMovimiento(float horizontal)
    {
        if ((mirandoDerecha == true && horizontal < 0) || (mirandoDerecha == false && horizontal > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
