using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioImagenTutorial : MonoBehaviour
{
    public Sprite[] imagen;
    Button botonDelante;
    Button botonDetras;

    GameObject info;
    int index = 0;
    private void Awake()
    {
        botonDelante = GameObject.Find("BDelante").GetComponent<Button>();
        botonDetras = GameObject.Find("BAtras").GetComponent<Button>();

        info = GameObject.Find("info_Tutorial");

        botonDelante.onClick.AddListener(delegate () { CambioImagenDelante(); });
        botonDetras.onClick.AddListener(delegate () { CambioImagenDetras(); });
    }
    public void CambioImagenDelante()
    {
        if (index < 4)
            index += 1;
    }

    public void CambioImagenDetras()
    {
        if (index > 0)
            index -= 1;
    }

    private void Update()
    {
        info.GetComponent<Image>().sprite = imagen[index];
    }
}
