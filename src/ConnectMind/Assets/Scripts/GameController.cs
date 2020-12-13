using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    GameObject pantallaJuego;
    GameObject pantallaResultado;

    GameObject minijuego;
    GameObject nivelFacil;
    GameObject nivelNormal;
    GameObject nivelDificil;

    GameObject nivel;
    int numeroRonda;

    GameObject[] puntosRondasJuego;
    GameObject[] puntosRondasVD;
    GameObject[] puntosResultado;
    GameObject[] estrellasResultado;

    GameObject nivelVD;

    GameObject rondaVD;
    GameObject botonAceptarVictoria;

    public Sprite Derrota;
    public Sprite Victoria;

    public Sprite[] spritesBotones;

    int puntuacion;
    GameObject recuadroPuntuacion;

    // Start is called before the first frame update
    void Awake()
    {
        //coger pantallas 
        pantallaJuego = GameObject.Find("Pantalla_juego");
        rondaVD = GameObject.Find("Ronda_VD");
        pantallaResultado = GameObject.Find("Resultado");

        //Elementos pantalla juego
        minijuego = GameObject.Find("Minijuego");
        nivelFacil = minijuego.transform.GetChild(0).gameObject;
        nivelNormal = minijuego.transform.GetChild(1).gameObject;
        nivelDificil = minijuego.transform.GetChild(2).gameObject;
        nivel = pantallaJuego.transform.GetChild(2).gameObject;

        numeroRonda = 1;
        puntuacion = 0;

        //elementos pantallaVD
        nivelVD = rondaVD.transform.GetChild(1).gameObject;


        puntosRondasJuego = new GameObject[8];
        puntosRondasVD = new GameObject[8];
        puntosResultado = new GameObject[8];


        for (int i = 0; i < 8; i++)
        {
            puntosRondasJuego[i] = pantallaJuego.transform.GetChild(4).GetChild(i).gameObject;
            puntosRondasVD[i] = rondaVD.transform.GetChild(2).GetChild(i).gameObject;
            puntosResultado[i] = pantallaResultado.transform.GetChild(2).GetChild(i).gameObject;
        }


        //elementos pantallaResultado

        recuadroPuntuacion = pantallaResultado.transform.GetChild(3).gameObject;
        estrellasResultado = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            estrellasResultado[i] = pantallaResultado.transform.GetChild(4).GetChild(i).gameObject;
        }

        //dar funcionalidad a los botones
        botonAceptarVictoria = rondaVD.transform.GetChild(3).gameObject;
        botonAceptarVictoria.GetComponent<Button>().onClick.AddListener(delegate () { funcionBotonAceptar(); });

    }

    private void Start()
    {
        rondaVD.SetActive(false);
        pantallaResultado.SetActive(false);
        GameObject.Find("NumeroRonda").GetComponent<Text>().text = numeroRonda.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (numeroRonda > 8)
        {
            resultado();
        }
        else
        {
            levelPass();
        }
    }

    void levelPass()
    {
        if (rondaVD.activeSelf == false)
        {

            if (nivelFacil.activeSelf == true)
            {

                if (nivelFacil.GetComponent<F_Calculadora>().end == true && nivelFacil.GetComponent<F_Calculadora>().acierto == true)
                {
                    pantallaJuego.SetActive(false);
                    rondaVD.transform.GetChild(0).GetComponent<Image>().sprite = Victoria;
                    rondaVD.SetActive(true);
                    rondaVD.transform.GetChild(4).GetComponent<Text>().text = numeroRonda.ToString();
                    puntosRondasVD[numeroRonda - 1].SetActive(true);
                    puntosRondasVD[numeroRonda - 1].GetComponent<Image>().sprite = spritesBotones[0];
                    nivelVD.GetComponent<Image>().sprite = spritesBotones[0];
                    puntuacion += 25;

                }
                else if (nivelFacil.GetComponent<F_Calculadora>().end == true && nivelFacil.GetComponent<F_Calculadora>().acierto == false)
                {
                    pantallaJuego.SetActive(false);
                    rondaVD.transform.GetChild(0).GetComponent<Image>().sprite = Derrota;
                    rondaVD.SetActive(true);
                    rondaVD.transform.GetChild(4).GetComponent<Text>().text = numeroRonda.ToString();
                    puntosRondasVD[numeroRonda - 1].SetActive(true);
                    puntosRondasVD[numeroRonda - 1].GetComponent<Image>().sprite = spritesBotones[1];
                    nivelVD.GetComponent<Image>().sprite = spritesBotones[1];

                }
            }
            else if (nivelNormal.activeSelf == true)
            {
                if (nivelNormal.GetComponent<N_Calculadora>().end == true && nivelNormal.GetComponent<N_Calculadora>().acierto == true)
                {
                    pantallaJuego.SetActive(false);
                    rondaVD.transform.GetChild(0).GetComponent<Image>().sprite = Victoria;
                    rondaVD.SetActive(true);
                    rondaVD.transform.GetChild(4).GetComponent<Text>().text = numeroRonda.ToString();
                    puntosRondasVD[numeroRonda - 1].SetActive(true);
                    puntosRondasVD[numeroRonda - 1].GetComponent<Image>().sprite = spritesBotones[2];
                    nivelVD.GetComponent<Image>().sprite = spritesBotones[2];
                    puntuacion += 60;
                }
                else if (nivelNormal.GetComponent<N_Calculadora>().end == true && nivelNormal.GetComponent<N_Calculadora>().acierto == false)
                {
                    pantallaJuego.SetActive(false);
                    rondaVD.transform.GetChild(0).GetComponent<Image>().sprite = Derrota;
                    rondaVD.SetActive(true);
                    rondaVD.transform.GetChild(4).GetComponent<Text>().text = numeroRonda.ToString();
                    puntosRondasVD[numeroRonda - 1].SetActive(true);
                    puntosRondasVD[numeroRonda - 1].GetComponent<Image>().sprite = spritesBotones[3];
                    nivelVD.GetComponent<Image>().sprite = spritesBotones[3];
                }
            }
            else
            {
                if (nivelDificil.GetComponent<D_Calculadora>().end == true && nivelDificil.GetComponent<D_Calculadora>().acierto == true)
                {
                    pantallaJuego.SetActive(false);
                    rondaVD.transform.GetChild(0).GetComponent<Image>().sprite = Victoria;
                    rondaVD.SetActive(true);
                    rondaVD.transform.GetChild(4).GetComponent<Text>().text = numeroRonda.ToString();
                    puntosRondasVD[numeroRonda - 1].SetActive(true);
                    puntosRondasVD[numeroRonda - 1].GetComponent<Image>().sprite = spritesBotones[4];
                    nivelVD.GetComponent<Image>().sprite = spritesBotones[4];
                    puntuacion += 50;
                }
                else if (nivelDificil.GetComponent<D_Calculadora>().end == true && nivelDificil.GetComponent<D_Calculadora>().acierto == false)
                {
                    pantallaJuego.SetActive(false);
                    rondaVD.transform.GetChild(0).GetComponent<Image>().sprite = Derrota;
                    rondaVD.SetActive(true);
                    rondaVD.transform.GetChild(4).GetComponent<Text>().text = numeroRonda.ToString();
                    puntosRondasVD[numeroRonda - 1].SetActive(true);
                    puntosRondasVD[numeroRonda - 1].GetComponent<Image>().sprite = spritesBotones[5];
                    nivelVD.GetComponent<Image>().sprite = spritesBotones[5];
                }
            }
        }
    }


    void funcionBotonAceptar()
    {

        rondaVD.SetActive(false);
        pantallaJuego.SetActive(true);
        puntosRondasJuego[numeroRonda - 1].SetActive(true);
        puntosRondasJuego[numeroRonda - 1].GetComponent<Image>().sprite = puntosRondasVD[numeroRonda - 1].GetComponent<Image>().sprite;
        numeroRonda++;
        GameObject.Find("NumeroRonda").GetComponent<Text>().text = numeroRonda.ToString();

        cambioMinijuego();

    }

    void cambioMinijuego()
    {
        if (rondaVD.transform.GetChild(0).GetComponent<Image>().sprite == Victoria)
        {
            if (nivelFacil.activeSelf == true)
            {
                nivelFacil.SetActive(false);
                nivelNormal.SetActive(true);
                nivelNormal.GetComponent<N_Calculadora>().Start();
                nivel.GetComponent<Image>().sprite = spritesBotones[7];
            }
            else if (nivelNormal.activeSelf == true)
            {
                nivelNormal.SetActive(false);
                nivelDificil.SetActive(true);
                nivelDificil.GetComponent<D_Calculadora>().Start();
                nivel.GetComponent<Image>().sprite = spritesBotones[8];
            }
            else
            {
                nivelDificil.GetComponent<D_Calculadora>().Start();
                nivel.GetComponent<Image>().sprite = spritesBotones[8];
            }
        }
        else
        {
            if (nivelFacil.activeSelf == true)
            {
                nivelFacil.GetComponent<F_Calculadora>().Start();
                nivel.GetComponent<Image>().sprite = spritesBotones[6];

            }
            else if (nivelNormal.activeSelf == true)
            {
                nivelNormal.SetActive(false);
                nivelFacil.SetActive(true);
                nivelFacil.GetComponent<F_Calculadora>().Start();
                nivel.GetComponent<Image>().sprite = spritesBotones[6];
            }
            else
            {
                nivelDificil.SetActive(false);
                nivelNormal.SetActive(true);
                nivelNormal.GetComponent<N_Calculadora>().Start(); ;
                nivel.GetComponent<Image>().sprite = spritesBotones[7];
            }
        }
    }

    void resultado()
    {
        if (pantallaResultado.activeSelf == false)
        {
            pantallaResultado.SetActive(true);

            for (int i = 0; i < 8; i++)
            {
                puntosResultado[i].GetComponent<Image>().sprite = puntosRondasVD[i].GetComponent<Image>().sprite;
            }

            pantallaJuego.SetActive(false);
            rondaVD.SetActive(false);

            recuadroPuntuacion.GetComponent<Text>().text = puntuacion.ToString();

            for (int i = 0; i < 4; i++)
            {
                if (puntuacion < 40)
                {
                    estrellasResultado[i].GetComponent<Image>().sprite = spritesBotones[10];
                }
                else if (puntuacion >= 40 && puntuacion < 110)
                {
                    if (i == 0)
                    {
                        estrellasResultado[i].GetComponent<Image>().sprite = spritesBotones[9];
                    }
                    else
                    {
                        estrellasResultado[i].GetComponent<Image>().sprite = spritesBotones[10];
                    }
                }
                else if (puntuacion >= 110 && puntuacion < 180)
                {
                    if (i == 0 || i == 1)
                    {
                        estrellasResultado[i].GetComponent<Image>().sprite = spritesBotones[9];
                    }
                    else
                    {
                        estrellasResultado[i].GetComponent<Image>().sprite = spritesBotones[10];
                    }
                }
                else if (puntuacion >= 180 && puntuacion < 240)
                {
                    if (i == 0 || i == 1 || i == 3)
                    {
                        estrellasResultado[i].GetComponent<Image>().sprite = spritesBotones[9];
                    }
                    else
                    {
                        estrellasResultado[i].GetComponent<Image>().sprite = spritesBotones[10];
                    }
                }
                else if (puntuacion >= 240)
                {

                    estrellasResultado[i].GetComponent<Image>().sprite = spritesBotones[9];


                }
            }


        }
    }
}
