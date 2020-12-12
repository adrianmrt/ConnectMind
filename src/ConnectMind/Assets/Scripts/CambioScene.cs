using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScene : MonoBehaviour
{
    public int escena;

    public void cambioEscena()
    {
        if (transform.parent.transform.parent != null)
        {
            if (transform.parent.transform.parent.name == "PopUpNormal(Clone)")
            {
                this.escena = 3;
            }
            else if (transform.parent.transform.parent.name == "PopUpDificil(Clone)")
            {
                this.escena = 4;
            }
        }
        SceneManager.LoadScene(this.escena);
    }
}