using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpSystem : MonoBehaviour
{
    
    public GameObject prefab;
    bool active = false;
    private Transform canvas;
    private GameObject panel;

    private void Awake()
    {
        canvas = transform.parent;
        panel = Instantiate(prefab,canvas);
    }

    public void popUpWork()
    {
        if (active == false)
        {
            panel.SetActive(true);
            active = true;
        }else if (active == true)
        {
            panel.SetActive(false);
            active = false;
        }
    }

}
