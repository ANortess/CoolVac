using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardarSonido : MonoBehaviour
{
    public Slider controlMusica;

    private void Start()
    {
        controlMusica.value = PlayerPrefs.GetFloat("GuardarSonido", 1f);
    }

    public void guardarMusica()
    {
        PlayerPrefs.SetFloat("GuardarSonido", controlMusica.value);
    }
}
