using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairInGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject selectedcamiseta;
    public GameObject Player;

    private Sprite playersprite;

    void Start()
    {
        playersprite = selectedcamiseta.GetComponent<SpriteRenderer>().sprite;

        Player.GetComponent<SpriteRenderer>().sprite = playersprite;
    }
}
