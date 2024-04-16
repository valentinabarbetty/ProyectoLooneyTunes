using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameConfig : MonoBehaviour
{
    private static CanvasGameConfig instance;
    public Canvas CanvasGame;
    public Canvas CanvasMenu;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        B_tecla();
    }

    public void B_OnHandleButtonExit()
    {
        CanvasGame.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(true);
        Game.GetInstance().SetIsStarted(false);
    }

    public static CanvasGameConfig GetInstance()
    {
        return instance == null ? instance = new CanvasGameConfig() : instance;
    }

    public void B_tecla(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasGame.gameObject.SetActive(false);
            CanvasMenu.gameObject.SetActive(true);
            Game.GetInstance().SetIsStarted(false);
        }
    }
}
