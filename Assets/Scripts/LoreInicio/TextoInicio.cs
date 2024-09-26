using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextoInicio : MonoBehaviour
{
    float speed = 100.0f;
    float boundaryTextEnd = 2756;

    [SerializeField] private Transform myGorectTransform;

    void Start()
    {
        myGorectTransform = gameObject.GetComponent<Transform>();
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
