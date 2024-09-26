using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPersonaje : MonoBehaviour
{
    public static GameManagerPersonaje Instance;

    public List<DiseñadorSkin> skin;
    public List<DiseñadorPelo> pelo;
    public List<DiseñadorRopa> ropa;

    private void Awake()
    {
        if (GameManagerPersonaje.Instance == null)
        {
            GameManagerPersonaje.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
