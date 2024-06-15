using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPerfilConfig : MonoBehaviour
{
    
    public Canvas CanvasPerfil;
    public Canvas CanvasMenu;

  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

 public void B_OnHandleButtonPerfil()
    {
        CanvasMenu.gameObject.SetActive(true);
        CanvasPerfil.gameObject.SetActive(false);
    }
   
}
