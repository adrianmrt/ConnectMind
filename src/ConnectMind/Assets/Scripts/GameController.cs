using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameObject pantallaJuego;

    GameObject minijuego;
    GameObject nivelFacil;
    GameObject nivelNormal;
    GameObject nivelDificil;

    GameObject nivel;
    string numeroRonda;

    GameObject rondaVictoria;
    GameObject rondaDerrota;

    // Start is called before the first frame update
    void Awake()
    {
        pantallaJuego= GameObject.Find("Pantalla_juego");

        minijuego = GameObject.Find("Minijuego");
        nivelFacil = minijuego.transform.GetChild(0).gameObject;
        nivelNormal = minijuego.transform.GetChild(1).gameObject;
        nivelDificil = minijuego.transform.GetChild(2).gameObject;
        nivel = GameObject.Find("Nivel");
 

        rondaVictoria = GameObject.Find("Ronda_Victoria");
        rondaDerrota = GameObject.Find("Ronda_Derrota");
    }

    private void Start()
    {
        rondaVictoria.SetActive(false);
        rondaDerrota.SetActive(false);
        numeroRonda = GameObject.Find("NumeroRonda").GetComponent<Text>().text = "2";
    }

    // Update is called once per frame
    void Update()
    {
        if (rondaVictoria.activeSelf == false && rondaDerrota.activeSelf == false)
        {
            if (nivelFacil.GetComponent<F_Calculadora>().end == true && nivelFacil.GetComponent<F_Calculadora>().acierto==true)
            {
                pantallaJuego.SetActive(false);
                rondaVictoria.SetActive(true);
                rondaVictoria.transform.GetChild(4).GetComponent<Text>().text = numeroRonda;
                Debug.Log("rondaVictoria");
            }
            else if (nivelFacil.GetComponent<F_Calculadora>().end == true && nivelFacil.GetComponent<F_Calculadora>().acierto == false)
            {
                pantallaJuego.SetActive(false);
                rondaDerrota.SetActive(true);
                rondaDerrota.transform.GetChild(4).GetComponent<Text>().text = numeroRonda;
                Debug.Log("rondaVictoria");
            }
        }
    }
}
