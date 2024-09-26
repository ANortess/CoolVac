using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public int TPx = -400;
    public int TPy = 0;

    public GameObject playerGO;
    public MisiónJugar simon;

    [SerializeField] private GameObject panelInventario;

    public GameObject panelExplicación;
    public GameObject panelSimon;

    public GameObject botonOpciones;
    public GameObject botonMapa;

    public GameManager ganado;

    public bool seguirTexto = false;

    // Update is called once per frame
    void Update()
    {
        simon = FindObjectOfType<MisiónJugar>();
        if (simon.jugar == true)
        {
            panelExplicación.SetActive(true);
            botonMapa.SetActive(false);
            botonOpciones.SetActive(false);
            //StartCoroutine(teletransporte());
            playerGO.SetActive(false);
        }

        ganado = FindObjectOfType<GameManager>();
        if (ganado.pasarSimon == true)
        {
            simon.jugar = false;
            ganado.pasarSimon = false;
            VolverMapa();
        }

    }
    public void EmpezarJuego()
    {
        playerGO.transform.position = new Vector2(TPx, TPy);
        simon.jugar = false;
        panelExplicación.SetActive(false);
        panelSimon.SetActive(true);
    }
    private void VolverMapa()
    {
        simon.jugar = false;

        //StartCoroutine(volver());
        playerGO.transform.position = new Vector2(-126, -86);

        playerGO.SetActive(true);
        botonMapa.SetActive(true);
        botonOpciones.SetActive(true);
        panelSimon.SetActive(false);
        panelInventario.SetActive(true);

        seguirTexto = true;
    }
    /*IEnumerator teletransporte()
    {
        yield return new WaitForSeconds(0.05f);
        playerGO.transform.position = new Vector2(TPx, TPy);
    }
    IEnumerator volver()
    {
        yield return new WaitForSeconds(0.05f);
        playerGO.transform.position = new Vector2(150, -70);
    }*/
}
