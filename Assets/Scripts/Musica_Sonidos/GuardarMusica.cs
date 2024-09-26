using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardarMusica : MonoBehaviour
{
    public Slider controlMusica;

    private void Start()
    {
        controlMusica.value = PlayerPrefs.GetFloat("GuardarMusica", 1f);
    }

    public void guardarMusica()
    {
        PlayerPrefs.SetFloat("GuardarMusica", controlMusica.value);
    }
}
