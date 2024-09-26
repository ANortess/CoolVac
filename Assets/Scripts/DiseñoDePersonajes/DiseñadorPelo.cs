using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

[CreateAssetMenu(fileName = "nuevoPelo", menuName = "Pelo")]
public class DiseñadorPelo : ScriptableObject
{
    public GameObject peloJugable;

    public Sprite imagenPelo;

}
