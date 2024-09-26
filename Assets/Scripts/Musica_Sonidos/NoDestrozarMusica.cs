using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoDestrozarMusica : MonoBehaviour
{
    public static NoDestrozarMusica instance;
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
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TextoInicio")
        {
            NoDestrozarMusica.instance.GetComponent<AudioSource>().Pause();
        }
    }

}
