using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_menu : MonoBehaviour
{
    private bool canvasActivo = false;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             canvasActivo = !canvasActivo;
            canvas.gameObject.SetActive(canvasActivo);
        }
    }
    public  void ToggleCanvas()
    {
        canvasActivo = false;
        canvas.gameObject.SetActive(false);
    }
}
