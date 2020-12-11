using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioImagen : MonoBehaviour
{
    public Sprite imagen1;
    public Sprite imagen2;

    public void cambioImagen()
    {
        if (gameObject.gameObject.GetComponent<Image>().sprite == imagen1)
        {
            gameObject.GetComponent<Image>().sprite = imagen2;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = imagen1;

        }
    }
}
