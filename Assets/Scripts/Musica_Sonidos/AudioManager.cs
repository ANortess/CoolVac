using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioMixerGroup musicaMixerGrupo;
    [SerializeField] private AudioMixerGroup efectosdesonidosMixerGrupo;
    [SerializeField] private Sonido[] sonidos;

    private void Awake()
    {
        Instance = this;

        foreach (Sonido s in sonidos)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioclip;
            s.source.loop = s.repetir;
            s.source.volume = s.volumen;

            switch (s.audioType)
            {
                case Sonido.AudioTypes.EfectosDeSonido:
                    s.source.outputAudioMixerGroup = efectosdesonidosMixerGrupo;
                    break;
                case Sonido.AudioTypes.Musica:
                    s.source.outputAudioMixerGroup = musicaMixerGrupo;
                    break;
            }

            if (s.empezar)
            {
                s.source.Play();
            }
        }
    }

    public void Play(string nombreclip)
    {
        Sonido s = Array.Find(sonidos, dummySound => dummySound.nombreclip == nombreclip);
        if (s == null)
        {
            Debug.LogError("El sonido" + nombreclip + " no existe.");
            return;
        }
        s.source.Play();
    }

    public void Stop(string nombreclip)
    {
        Sonido s = Array.Find(sonidos, dummySound => dummySound.nombreclip == nombreclip);
        if (s == null)
        {
            Debug.LogError("El sonido" + nombreclip + "no existe.");
            return;
        }
        s.source.Stop();
    }

    public void CargarMixerVolumen()
    {
        musicaMixerGrupo.audioMixer.SetFloat(("Musica Volumen"), Mathf.Log10(AudioOpciones.MusicaVolumen) * 20);
        efectosdesonidosMixerGrupo.audioMixer.SetFloat(("EfectosDeSonido Volumen"), Mathf.Log10(AudioOpciones.EfectosDeSonidoVolumen) * 20);
    }
}
