using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardarBrillo : MonoBehaviour
{
    public Slider controlBrillo;

    private void Start()
    {
        controlBrillo.value = PlayerPrefs.GetFloat("GuardarBrillo", 1f);
    }

    public void guardarBrillo()
    {
        PlayerPrefs.SetFloat("GuardarBrillo", controlBrillo.value);
    }
}
