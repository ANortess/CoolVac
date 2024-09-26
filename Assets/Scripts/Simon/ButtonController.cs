using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public int thisButtonNumber;

    private SpriteRenderer theSprite;

    private GameManager theGM;

    private AudioSource theSound;

    public GameManager sal;

    // Start is called before the first frame update
    void Start()
    {
        theSprite = GetComponent<SpriteRenderer>();
        theGM = FindObjectOfType<GameManager>();
        theSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sal = FindObjectOfType<GameManager>();
        if (sal.salir == true)
        {
            theSound.Stop();
        }
    }

    void OnMouseDown()
    {
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);
        theSound.Play();
    }

    void OnMouseUp()
    {
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.5f);
        theGM.ColourPressed(thisButtonNumber); // llamamos a la funcion de GameManager y le pasamos el botón que pulsamos ya que lo requiere
        theSound.Stop();
    }
}
