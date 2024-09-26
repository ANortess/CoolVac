using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoInventario : MonoBehaviour
{
    public float speed = 80.0f;
    public float abrir = 0f;
    public float cerrar = 0f;

    [SerializeField] private RectTransform myGorectTransform;

    public int parametro = 0;

    public void Start()
    {
        myGorectTransform = gameObject.GetComponent<RectTransform>();
    }
    public void apretarBoton()
    {
        if (parametro == 0)
        {
            StartCoroutine(Cerrar());
            parametro = 1;
        }
        if (parametro == 1)
        {
            StartCoroutine(Abrir());
            parametro = 0;
        }

    }
    IEnumerator Cerrar()
    {
        while (myGorectTransform.localPosition.x < cerrar)
        {
            myGorectTransform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator Abrir()
    {
        while (myGorectTransform.localPosition.x < abrir)
        {
            myGorectTransform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
    }
}
