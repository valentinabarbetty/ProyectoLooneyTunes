using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenuConfig : MonoBehaviour
{  
    private static CanvasMenuConfig instance;
    public Canvas CanvasMenu;

     public Canvas CanvasLevels;
    public Canvas CanvasGame;

    public Canvas CanvasPerfil;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
 
    }

    public void B_OnHandleButtonStart()
    {
        CanvasMenu.gameObject.SetActive(false);
        CanvasGame.gameObject.SetActive(true);
        Game.GetInstance().SetIsStarted(true);
        Game.GetInstance().StartGame();
    }

     public void B_OnHandleButtonPerfil()
    {
        CanvasMenu.gameObject.SetActive(false);
        CanvasPerfil.gameObject.SetActive(true);
    }

    public void B_OnHandleButtonLevell()
    {
        CanvasMenu.gameObject.SetActive(false);
        CanvasLevels.gameObject.SetActive(true);
    }
     public void ExitGame()
    {
        // Aquí puedes poner cualquier lógica adicional que necesites antes de salir del juego
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public static CanvasMenuConfig GetInstance()
    {
        return instance == null ? instance = new CanvasMenuConfig() : instance;
    }
}

