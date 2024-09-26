using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNubes : MonoBehaviour
{
    public float speed = 80.0f;
    public float boundaryTextEnd = 2756;

    [SerializeField] private Transform myGorectTransform;

    void Start()
    {
        myGorectTransform = gameObject.GetComponent<Transform>();
        StartCoroutine(AutoScrollText());

    }
    IEnumerator AutoScrollText()
    {
        while (myGorectTransform.localPosition.x < boundaryTextEnd)
        {
            myGorectTransform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }
    }
}
