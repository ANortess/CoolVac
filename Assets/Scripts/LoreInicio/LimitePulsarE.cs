using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LimitePulsarE : MonoBehaviour
{
    float speed = 100.0f;
    float boundaryTextEnd = -435;

    [SerializeField] private RectTransform myGorectTransform;


    void Start()
    {
        myGorectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("PrimerMapa");
        }
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
