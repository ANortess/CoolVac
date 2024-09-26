using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSeleccionPelo : MonoBehaviour
{
    private int index;
    [SerializeField] private Image imagen;
    private GameManagerPersonaje gameManager;

    private void Start()
    {
        gameManager = GameManagerPersonaje.Instance;

        index = PlayerPrefs.GetInt("PeloIndex");

        if (index > gameManager.pelo.Count - 1)
        {
            index = 0;
        }

        CambiarPantalla();
    }
    public void CambiarPantalla()
    {
        PlayerPrefs.SetInt("PeloIndex", index);
        imagen.sprite = gameManager.pelo[index].imagenPelo;
    }

    public void SiguientePelo()
    {
        if (index == gameManager.pelo.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        CambiarPantalla();
    }

    public void AnteriorPelo()
    {
        if (index == 0)
        {
            index = gameManager.pelo.Count - 1;
        }
        else
        {
            index -= 1;
        }

        CambiarPantalla();
    }
}
