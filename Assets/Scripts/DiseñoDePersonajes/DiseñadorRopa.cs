using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

[CreateAssetMenu(fileName = "nuevaRopa", menuName = "Ropa")]
public class DiseñadorRopa : ScriptableObject
{
    public GameObject ropaJugable;

    public Sprite imagenRopa;
}
