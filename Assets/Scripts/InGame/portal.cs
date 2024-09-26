using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{

    public GameObject portalSalida;
    public GameObject playerGO;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(teletransporte());
        }
    }
    IEnumerator teletransporte()
    {
        yield return new WaitForSeconds(0.05f);
        playerGO.transform.position = new Vector2(portalSalida.transform.position.x, portalSalida.transform.position.y);
    }
}
