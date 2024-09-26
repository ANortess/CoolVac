using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinInGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject selectedSkin;
    public GameObject Player;

    private Sprite playersprite;

    void Start()
    {
        playersprite = selectedSkin.GetComponent<SpriteRenderer>().sprite;

        Player.GetComponent<SpriteRenderer>().sprite = playersprite;
    }
}
