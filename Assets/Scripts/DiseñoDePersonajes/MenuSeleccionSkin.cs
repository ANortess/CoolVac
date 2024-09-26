using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSeleccionSkin : MonoBehaviour
{
    private int index;
    [SerializeField] private Image imagen;
    private GameManagerPersonaje gameManager;

    private void Start()
    {
        gameManager = GameManagerPersonaje.Instance;

        index = PlayerPrefs.GetInt("SkinIndex");

        if (index > gameManager.skin.Count - 1)
        {
            index = 0;
        }

        CambiarPantalla();
    }
    public void CambiarPantalla()
    {
        PlayerPrefs.SetInt("SkinIndex", index);
        imagen.sprite = gameManager.skin[index].imagenSkin;
    }

    public void SiguienteSkin()
    {
        if ( index == gameManager.skin.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        CambiarPantalla();
    }

    public void AnteriorSkin()
    {
        if (index == 0)
        {
            index = gameManager.skin.Count -1;
        }
        else
        {
            index -= 1;
        }

        CambiarPantalla();
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
