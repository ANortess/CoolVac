using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPersonaje : MonoBehaviour
{
    public static GameManagerPersonaje Instance;

    public List<DiseņadorSkin> skin;
    public List<DiseņadorPelo> pelo;
    public List<DiseņadorRopa> ropa;

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
