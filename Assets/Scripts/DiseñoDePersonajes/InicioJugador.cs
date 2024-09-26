using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugador : MonoBehaviour
{
    public GameObject Jugador;
    private void Start()
    {
        int indexSkin = PlayerPrefs.GetInt("SkinIndex");
        GameObject skin = Instantiate(GameManagerPersonaje.Instance.skin[indexSkin].skinJugable, transform.position, Quaternion.identity);
        skin.transform.parent = Jugador.transform;

        int indexPelo = PlayerPrefs.GetInt("PeloIndex");
        GameObject pelo = Instantiate(GameManagerPersonaje.Instance.pelo[indexPelo].peloJugable, transform.position, Quaternion.identity);
        pelo.transform.parent = Jugador.transform;

        int indexRopa = PlayerPrefs.GetInt("RopaIndex");
        GameObject ropa = Instantiate(GameManagerPersonaje.Instance.ropa[indexRopa].ropaJugable, transform.position, Quaternion.identity);
        ropa.transform.parent = Jugador.transform;
    }
}
