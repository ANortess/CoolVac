using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestrozarBrillo : MonoBehaviour
{
    public static NoDestrozarBrillo instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
