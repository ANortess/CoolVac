using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOpciones : MonoBehaviour
{
    public static float MusicaVolumen { get; private set; }
    public static float EfectosDeSonidoVolumen { get; private set; }

    public void CambiarMusica(float value)
    {
        MusicaVolumen = value;

        AudioManager.Instance.CargarMixerVolumen();
    }

    public void CambiarEfectoDeSonido(float value)
    {
        EfectosDeSonidoVolumen = value;

        AudioManager.Instance.CargarMixerVolumen();
    }
}
