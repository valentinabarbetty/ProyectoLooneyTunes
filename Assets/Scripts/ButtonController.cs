using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonController : MonoBehaviour
{
    //public Button botonClose;
    public Button botonStart;
    public Canvas canvas;
   // public Canvas canvas;
    //public Image imagen;

    //public TextMeshProUGUI texto;


    // Start is called before the first frame update
    void Start()
    {
       // botonClose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void B_Show(){
        Debug.Log("Button Clicked! ");
        //botonClose.gameObject.SetActive(true);
        botonStart.gameObject.SetActive(false);
        //texto.enabled = false;
        canvas.gameObject.SetActive(false);
        //imagen.gameObject.SetActive(false);
    }
    public void B_NoShow(){
        Debug.Log("Button Clicked! ");
        //botonClose.gameObject.SetActive(false);
        botonStart.gameObject.SetActive(true);
        //texto.enabled = true;
        canvas.gameObject.SetActive(true);
        //imagen.gameObject.SetActive(true);
    }
}

