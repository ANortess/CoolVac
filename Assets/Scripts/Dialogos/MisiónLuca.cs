using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MisiónLuca : MonoBehaviour
{
    [SerializeField] private GameObject botonOpciones;
    [SerializeField] private GameObject botonMapa;

    [SerializeField] private GameObject exclamacionDialogo;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField, TextArea(4, 6)] private string[] lineasDialogo;

    [SerializeField] private GameObject panelMachacar;
    [SerializeField] private GameObject jugador;

    private float tiempoDialogo = 0.05f;


    private bool JugadorEnRango = false;
    private bool dialogoActivo;
    private int indexlineas;

    private bool noRepetir = false;
    public bool terminarJuego= true;

    public SangreAPositivo seguirLuca;
    void Update()
    {
        seguirLuca = FindObjectOfType<SangreAPositivo>();
        if (seguirLuca.cogerSangre == true)
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

            noRepetir = true;
            seguirLuca.cogerSangre = false;
            panelMachacar.SetActive(true);
            jugador.SetActive(false);
            terminarJuego = false;

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
        if (collision.gameObject.CompareTag("Player") && seguirLuca.cogerSangre == true)
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
