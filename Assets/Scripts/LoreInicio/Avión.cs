using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avión : MonoBehaviour
{
    public float speed = 100.0f;
    public float boundaryTextEnd = -720;

    [SerializeField] private RectTransform myGorectTransform;

    void Start()
    {
        myGorectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());

    }
    IEnumerator AutoScrollText()
    {
        while (myGorectTransform.localPosition.x < boundaryTextEnd)
        {
            myGorectTransform.Translate(Vector3.right * speed * Time.deltaTime);
            yield return null;
        }
    }
}
