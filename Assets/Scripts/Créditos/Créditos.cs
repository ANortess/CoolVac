using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Créditos : MonoBehaviour
{
    float speed = 100.0f;
    float boundaryTextEnd = 3573;

    RectTransform myGorectTransform;
    [SerializeField]

    public AudioSource clipMusica;

    void Start()
    {
        myGorectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());

    }
    IEnumerator AutoScrollText()
    {
        while (myGorectTransform.localPosition.y < boundaryTextEnd)
        {
            myGorectTransform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
    }
}
