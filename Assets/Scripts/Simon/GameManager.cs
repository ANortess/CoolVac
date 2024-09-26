using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public SpriteRenderer[] colours;
    public AudioSource[] buttonSounds;

    private int colourSelect;

    public float stayLit;
    private float stayLitCounter;

    public float waitBetweenLights; // El tiempo entre luz y luz
    private float waitBetweenCounter; // Tiempo para resetear los valores

    private bool shouldBeLit;
    private bool shouldBeDark;

    public List<int> activeSequence; //Lista para los números que el jugador debe pulsar, usamos una lista para que sea ampliable (no como un array)
    private int positionInSequence;

    private bool gameActive;
    private int inputInSequence; // lo usamos para saber en que parte estamos de la secuencia para comprobar si es correcta o no la pulsación del jugador

    public AudioSource correct; // Sonido correcto
    public AudioSource incorrect; // Sonido incorrecto

    public Text scoreText;

    public bool pasarSimon = false;
    public bool salir = false;

    // Update is called once per frame
    void Update()
    {
        if (salir == false)
        {
            if (shouldBeLit)
            {
                stayLitCounter -= Time.deltaTime;

                if (stayLitCounter < 0)
                {
                    colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 0.5f); // la transparencia funciona entre 0 y 1f
                    buttonSounds[activeSequence[positionInSequence]].Stop();
                    shouldBeLit = false;

                    shouldBeDark = true;
                    waitBetweenCounter = waitBetweenLights;

                    positionInSequence++;
                }
            }

            if (shouldBeDark)
            {
                waitBetweenCounter -= Time.deltaTime;

                if (positionInSequence >= activeSequence.Count) // .Count para saber cuantos elementos hay en la lista, como un length
                {
                    shouldBeDark = false;
                    gameActive = true;
                }

                else
                {
                    if (waitBetweenCounter < 0) // si el contador es < 0 nos movemos a la siguiente luz en la secuencia
                    {
                        colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f); // la transparencia funciona entre 0 y 1f
                        buttonSounds[activeSequence[positionInSequence]].Play();

                        stayLitCounter = stayLit;
                        shouldBeLit = true;
                        shouldBeDark = false; // Lo ponemos a falso para que no añada a la lista de manera infinita
                    }
                }
            }
        }
        
    }
    public void IniciarSimon()
    {
        scoreText.text = "0";
        salir = false;
    }
    public void StartGame()
    {

        activeSequence.Clear(); // Para vaciar la lista

        positionInSequence = 0;
        inputInSequence = 0; // inicializamos a 0 la posición

        colourSelect = Random.Range(0, colours.Length); // va de 0 a 6-1... de 0 a 5

        activeSequence.Add(colourSelect);

        colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f); // la transparencia funciona entre 0 y 1f
        buttonSounds[activeSequence[positionInSequence]].Play();

        stayLitCounter = stayLit;
        shouldBeLit = true;

        scoreText.text = "0";
    }


    public void ColourPressed(int whichButton)
    {
        if(gameActive && salir == false)
        {
            if(activeSequence[inputInSequence] == whichButton)
            {
                Debug.Log("Correcto");

                inputInSequence++;

                if (inputInSequence >= activeSequence.Count)
                {
                    scoreText.text = "" + activeSequence.Count;

                    if (activeSequence.Count == 3)
                    {
                        pasarSimon = true;
                        salir = true;
                    }

                    positionInSequence = 0;
                    inputInSequence = 0;

                    colourSelect = Random.Range(0, colours.Length); // va de 0 a 6-1... de 0 a 5

                    activeSequence.Add(colourSelect);

                    colours[activeSequence[positionInSequence]].color = new Color(colours[activeSequence[positionInSequence]].color.r, colours[activeSequence[positionInSequence]].color.g, colours[activeSequence[positionInSequence]].color.b, 1f); // la transparencia funciona entre 0 y 1f
                    buttonSounds[activeSequence[positionInSequence]].Play();

                    stayLitCounter = stayLit;
                    shouldBeLit = true;

                    gameActive = false;

                    correct.Play(); // Para que suene si acertamos la secuencia
                }

            }
            else
            {
                Debug.Log("Erroneo");
                incorrect.Play();
                gameActive = false;
            }
        }
    }
}
