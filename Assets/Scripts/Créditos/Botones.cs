using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public void botonMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void botonSalir()
    {
        Application.Quit();
    }
}
