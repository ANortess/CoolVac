using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using System;
public class SangreBPositiva : MonoBehaviour
{
    [SerializeField] private GameObject botonOpciones;
    [SerializeField] private GameObject botonMapa;

    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField, TextArea(4, 6)] private string[] lineasDialogo;

    [SerializeField] private GameObject sangre;
    [SerializeField] private GameObject sangreBPositiva;

    public AudioSource sonidoSangre;

    private float tiempoDialogo = 0.05f;

    private bool JugadorEnRango = false;
    private bool dialogoActivo;
    private int indexlineas;

    private bool noRepetir = false;
    public bool inicioAdam = false;

    public MisiónSarah sangreB;
    void Update()
    {
        sangreB = FindObjectOfType<MisiónSarah>();
        if (sangreB.sangreActiva == true)
        {
            if (JugadorEnRango)
            {
                if (noRepetir == false)
                {
                    if (!dialogoActivo)
                    {
                        ComenzarDialogo();
                    }
                    else if (textoDialogo.text == lineasDialogo[indexlineas])
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            SiguienteLinea();
                        }
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            StopAllCoroutines();
                            textoDialogo.text = lineasDialogo[indexlineas];
                        }
                    }
                }
            }
        }
    }
    private void ComenzarDialogo()
    {
        dialogoActivo = true;
        panelDialogo.SetActive(true);
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

            noRepetir = true;

            Time.timeScale = 1f;

            sangre.SetActive(false);
            sangreBPositiva.SetActive(true);

            inicioAdam = true;
            sangreB.sangreActiva = false;

            sonidoSangre.Play();
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
        if (collision.gameObject.CompareTag("Player") && sangreB.sangreActiva == true)
        {
            JugadorEnRango = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            JugadorEnRango = false;
        }
    }
}
