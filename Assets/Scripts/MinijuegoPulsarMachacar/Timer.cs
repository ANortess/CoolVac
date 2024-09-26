using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject panelMantener;
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private GameObject botonOpciones;
    [SerializeField] private GameObject botonMapa;

    public float timer = 0;
    public bool seguirTimer;

    public EntregaJosué iniciar;
    public Mantén fin;
    public Movement mover;
    public MovimientoPrueba moverAnim;
    private void Start()
    {
        seguirTimer = true;
    }
    void Update()
    {
        fin = FindObjectOfType<Mantén>();
        iniciar = FindObjectOfType<EntregaJosué>();
        mover = FindObjectOfType<Movement>();
        moverAnim = FindObjectOfType<MovimientoPrueba>();
        if (iniciar.fin == true && seguirTimer == true)
        {
            timer += Time.deltaTime;
            
        }

        if(timer > 10)
        {
            panelMantener.SetActive(true);
            panelInventario.SetActive(false);
            botonMapa.SetActive(false);
            botonOpciones.SetActive(false);

            seguirTimer = false;
            timer = 0;

            mover.mover = false;
            moverAnim.seguirAnim = false;
        }
        if(fin.slider_StartingValue > 9.5)
        {
            panelMantener.SetActive(false);
            panelInventario.SetActive(true);
            botonMapa.SetActive(true);
            botonOpciones.SetActive(true);

            seguirTimer = true;

            mover.mover = true;
            moverAnim.seguirAnim = true;
        }
    }
}
