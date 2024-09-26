using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject PanelInicial;
    public GameObject PanelOpciones;
    public GameObject PanelInformacion;

    public void AbrirOpciones()
    {
        PanelInicial.SetActive(false);
        PanelOpciones.SetActive(true);
    }
    public void CerrarOpciones()
    {
        PanelInicial.SetActive(true);
        PanelOpciones.SetActive(false);
        PanelInformacion.SetActive(false);
    }
    public void AbrirInformacion()
    {
        PanelInformacion.SetActive(true);
        PanelInicial.SetActive(false);
    }
}
