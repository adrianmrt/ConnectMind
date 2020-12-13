using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N_Calculadora : MonoBehaviour
{
    private GameObject numero;
    private Transform [] botones;
    private string solucion;
    private string introducido;
    float timer;
    bool end;

    private void Awake()
    {
        setUpButtons();
    }
    void Start()
    {
        numero = GameObject.Find("Numero");
        solucion= randomNumber().ToString();
        numero.GetComponent<Text>().text = solucion;
        introducido = "";
        timer = 0;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += (Time.deltaTime);
        int seconds = (int)(timer % 60);

        if (seconds == 5)
        {
            if (numero.GetComponent<Text>().text == solucion)
            {
                numero.GetComponent<Text>().text = "";
            }
        }

    }

    int randomNumber()
    {
        return Random.Range(100000, 999999);
    }
      
    void buttonFunction(int index)
    {
        if (end == false)
        {
            if (index == 10)
            {
                functionCheck();
            }
            else if (index == 11)
            {

                introducido = "";
                numero.GetComponent<Text>().text = introducido;


            }
            else
            {
                introducido += index.ToString();
                numero.GetComponent<Text>().text = introducido;
            }
        }
        else
        {
            Start();
        }
    }


    void functionCheck()
    {
        if (introducido == solucion)
        {
            numero.GetComponent<Text>().text = "CORRECTO :)";
            

        }
        else
        {
            numero.GetComponent<Text>().text = "INCORRECTO :(";
            
        }

        end = true;
    }
    
    void setUpButtons()
    {

        botones = new Transform[12];

        for (int i = 0; i < 12; i++)
        {
            if (i == 10)
            {
                botones[i] = GameObject.Find("BotonCheck").transform;
                botones[i].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(10); });
            }
            else if (i == 11)
            {
                botones[i] = GameObject.Find("BotonVolver").transform;
                botones[i].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(11); });
            }
            else
            {
                botones[i] = GameObject.Find("Botones").transform.GetChild(i);

            }
        }
        botones[0].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(0); });
        botones[1].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(1); });
        botones[2].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(2); });
        botones[3].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(3); });
        botones[4].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(4); });
        botones[5].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(5); });
        botones[6].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(6); });
        botones[7].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(7); });
        botones[8].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(8); });
        botones[9].GetComponent<Button>().onClick.AddListener(delegate () { buttonFunction(9); });
    }


   
}
