using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class AnimacionTransicion : MonoBehaviour
{
    [SerializeField] private float transitionTime = 1f;

    public Animator transition;

    public void CambioEscenaATexto()
    {
        StartCoroutine(Personajes());
    }
    IEnumerator Personajes()
    {
        transition.SetTrigger("TransicionEscena");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("TextoInicio");
    }

    public void CambioEscenaAPersonaje()
    {
        StartCoroutine(Empezar());
    }
    IEnumerator Empezar()
    {
        transition.SetTrigger("TransicionEscena");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Personaje");
    }
}
