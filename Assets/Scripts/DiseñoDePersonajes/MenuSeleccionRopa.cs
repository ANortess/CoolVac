using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSeleccionRopa : MonoBehaviour
{
    private int index;
    [SerializeField] private Image imagen;
    private GameManagerPersonaje gameManager;

    private void Start()
    {
        gameManager = GameManagerPersonaje.Instance;

        index = PlayerPrefs.GetInt("RopaIndex");

        if (index > gameManager.ropa.Count - 1)
        {
            index = 0;
        }

        CambiarPantalla();
    }
    public void CambiarPantalla()
    {
        PlayerPrefs.SetInt("RopaIndex", index);
        imagen.sprite = gameManager.ropa[index].imagenRopa;
    }

    public void SiguienteRopa()
    {
        if (index == gameManager.ropa.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        CambiarPantalla();
    }

    public void AnteriorRopa()
    {
        if (index == 0)
        {
            index = gameManager.ropa.Count - 1;
        }
        else
        {
            index -= 1;
        }

        CambiarPantalla();
    }
}
