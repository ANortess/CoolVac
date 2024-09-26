using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject botonReanudar;

    [SerializeField] private GameObject botonReanudarMapa;

    [SerializeField] private GameObject botonPausaMapa;

    [SerializeField] private GameObject panelInventario;
    /*private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                ReanudarMenu();
            }
            else
            {
                PausaMenu();
            }
        }
       if (Input.GetKeyDown(KeyCode.M))
        {
            if (juegoPausado)
            {
                ReanudarMapa();
            }
            else
            {
                PausaMapa();
            }
        }
    }*/
    public void PausaMenu()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        botonPausaMapa.SetActive(false);
        botonReanudar.SetActive(true);
        panelInventario.SetActive(false);
    }

    public void ReanudarMenu()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        botonPausaMapa.SetActive(true);
        botonReanudar.SetActive(false);
        panelInventario.SetActive(true);
    }

    public void PausaMapa()
    {
        Time.timeScale = 0f;
        botonPausaMapa.SetActive(false);
        botonReanudarMapa.SetActive(true);
        panelInventario.SetActive(false);
    }

    public void ReanudarMapa()
    {
        Time.timeScale = 1f;
        botonPausaMapa.SetActive(true);
        botonReanudarMapa.SetActive(false);
        panelInventario.SetActive(true);
    }
    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
