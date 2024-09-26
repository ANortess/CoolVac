using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CajaCombones : MonoBehaviour
{
    [SerializeField] private GameObject botonOpciones;
    [SerializeField] private GameObject botonMapa;

    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField, TextArea(4, 6)] private string[] lineasDialogo;

    [SerializeField] private GameObject cajaBombones;

    [SerializeField] private GameObject PanelCaja;

    public AudioSource sonido;

    private float tiempoDialogo = 0.05f;

    private bool JugadorEnRango = false;
    private bool dialogoActivo;
    private int indexlineas;

    private bool noRepetir = false;
    public bool cajaCogida = false;

    public MisiónKevin caja;
    void Update()
    {
        caja = FindObjectOfType<MisiónKevin>();
        if (JugadorEnRango && caja.aparición == true)
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

            cajaBombones.SetActive(false);
            PanelCaja.SetActive(true);

            noRepetir = true;
            cajaCogida = true;

            sonido.Play();

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
        if (collision.gameObject.CompareTag("Player"))
        {
            JugadorEnRango = true;
            Debug.Log("Entra");
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
