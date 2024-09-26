using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntregaJosué : MonoBehaviour
{
    [SerializeField] private GameObject botonOpciones;
    [SerializeField] private GameObject botonMapa;

    [SerializeField] private GameObject exclamacionDialogo;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField, TextArea(4, 6)] private string[] lineasDialogo;

    [SerializeField] private GameObject aNegativa;
    [SerializeField] private GameObject aPositiva;
    [SerializeField] private GameObject bNegativa;
    [SerializeField] private GameObject bPositiva;
    [SerializeField] private GameObject oNegativa;

    [SerializeField] private GameObject cura;
    private float tiempoDialogo = 0.05f;


    private bool JugadorEnRango = false;
    private bool dialogoActivo;
    private int indexlineas;

    private bool noRepetir = false;
    public bool fin;

    public Sangre0Negativo inicioDialogo;
    void Update()
    {
        inicioDialogo = FindObjectOfType<Sangre0Negativo>();
        if (inicioDialogo.entregaVacunas == true)
        {
            if (JugadorEnRango && Input.GetKeyDown(KeyCode.E))
            {
                if (noRepetir == false)
                {
                    if (!dialogoActivo)
                    {
                        ComenzarDialogo();
                    }
                    else if (textoDialogo.text == lineasDialogo[indexlineas])
                    {
                        SiguienteLinea();
                    }
                    else
                    {
                        StopAllCoroutines();
                        textoDialogo.text = lineasDialogo[indexlineas];
                    }
                }
            }
        }
    }
    private void ComenzarDialogo()
    {
        dialogoActivo = true;
        panelDialogo.SetActive(true);
        exclamacionDialogo.SetActive(false);
        botonMapa.SetActive(false);
        botonOpciones.SetActive(false);
        indexlineas = 0;
        Time.timeScale = 0f;
        StartCoroutine(MostrarLineas());
    }
    private void SiguienteLinea()
    {
        indexlineas++;
        if (indexlineas < lineasDialogo.Length)
        {
            StartCoroutine(MostrarLineas());
        }
        else
        {
            dialogoActivo = false;
            panelDialogo.SetActive(false);
            botonMapa.SetActive(true);
            botonOpciones.SetActive(true);

            aNegativa.SetActive(false);
            aPositiva.SetActive(false);
            bNegativa.SetActive(false);
            bPositiva.SetActive(false);
            oNegativa.SetActive(false);

            cura.SetActive(true);
            fin = true;

            noRepetir = true;
            inicioDialogo.entregaVacunas = false;

            Time.timeScale = 1f;
        }
    }
    private IEnumerator MostrarLineas()
    {
        textoDialogo.text = string.Empty;

        foreach (char ch in lineasDialogo[indexlineas])
        {
            textoDialogo.text += ch;
            yield return new WaitForSecondsRealtime(tiempoDialogo);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && inicioDialogo.entregaVacunas == true)
        {
            JugadorEnRango = true;
            if (noRepetir == false)
            {
                exclamacionDialogo.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            JugadorEnRango = false;
            exclamacionDialogo.SetActive(false);
        }
    }
}
