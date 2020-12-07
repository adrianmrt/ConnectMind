using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScene : MonoBehaviour
{
    public int escena;

    public void cambioEscena()
    {
        SceneManager.LoadScene(escena);
    }
}