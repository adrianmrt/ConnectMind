using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F_Calculadora : MonoBehaviour
{
    private GameObject numero;
    private Transform [] botones;
    void Start()
    {
        numero = GameObject.Find("Numero");
        Debug.Log(numero.name);
        numero.GetComponent<Text>().text = randomNumber().ToString();

        botones = new Transform[12];
        for (int i = 0; i < 12; i++)
        {
            if (i == 10)
            {
                botones[i] = GameObject.Find("BotonCheck").transform;
            }
            else if (i == 11)
            {
                botones[i] = GameObject.Find("BotonVolver").transform;
            }
            else
            {
                botones[i] = GameObject.Find("Botones").transform.GetChild(i);
            }
            Debug.Log(botones[i].name);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int randomNumber()
    {
        return Random.Range(1000, 9999);
    }
}
