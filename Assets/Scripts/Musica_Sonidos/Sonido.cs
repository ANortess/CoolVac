using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sonido 
{
    public enum AudioTypes { Musica, EfectosDeSonido}
    public AudioTypes audioType;

    [HideInInspector] public AudioSource source;
    public string nombreclip;
    public AudioClip audioclip;
    public bool repetir;
    public bool empezar;

    [Range(0, 1)]
    public float volumen = 0.5f;
}
