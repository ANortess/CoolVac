using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

[CreateAssetMenu(fileName = "nuevaSkin", menuName = "Skin")]
public class DiseñadorSkin: ScriptableObject
{
    public GameObject skinJugable;

    public Sprite imagenSkin;

}
