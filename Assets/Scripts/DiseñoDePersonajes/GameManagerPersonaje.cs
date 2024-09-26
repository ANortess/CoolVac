using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPersonaje : MonoBehaviour
{
    public static GameManagerPersonaje Instance;

    public List<Dise�adorSkin> skin;
    public List<Dise�adorPelo> pelo;
    public List<Dise�adorRopa> ropa;

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
