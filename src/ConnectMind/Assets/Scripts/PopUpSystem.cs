using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpSystem : MonoBehaviour
{

    public GameObject prefab;
    private Transform canvas;
    private GameObject panel;
    public GameObject toDestroy;
    private GameObject principalCanvas;

    private void Start()
    {
        principalCanvas = GameObject.Find("Canvas");

    }
    public void popUpWork()
    {
        bool levelChange = true;
        canvas = transform.parent;

        if(canvas.name != "PopUpNormal" && canvas.name != "PopUpDificil")
        {
            levelChange = false;
        }


        if (canvas == principalCanvas && levelChange == false)
        {
            canvas = principalCanvas.transform;

        }

        panel = Instantiate(prefab, canvas);
    }

    public void popUpDestroy()
    {
        Destroy(toDestroy);
    }
}
