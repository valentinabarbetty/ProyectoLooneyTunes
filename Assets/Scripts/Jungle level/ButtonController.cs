using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    //public Button botonClose;
    private static ButtonController instance;
    public Button botonStart;
    public Canvas canvasWelcome;
    public Canvas canvasLevel;
        public bool pasarNivel1;
    public bool pasarNivel2;
    public bool pasarNivel3;
    public bool pasarNivel4;
    public int indiceNivel;
   // public Canvas canvasGame;
   // public Canvas canvas;
    //public Image imagen;

    //public TextMeshProUGUI texto;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
       // botonClose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void B_ShowStart(){
        Debug.Log("Button Start Clicked! ");
        //botonClose.gameObject.SetActive(true);
        botonStart.gameObject.SetActive(false);
        //texto.enabled = false;
        canvasWelcome.gameObject.SetActive(false);
        canvasLevel.gameObject.SetActive(true);
       // canvasGame.gameObject.SetActive(true);
        //imagen.gameObject.SetActive(false);
        //canvasWelcome.gameObject.SetActive(false);
        
        
      //  Game.GetInstance().SetIsStarted(true);
       // Game.GetInstance().StartGame();
        //Main.GetInstance().StartGame();
    }
    public void B_ShowLevel(){
        Debug.Log("Button Level Clicked! ");
        //botonClose.gameObject.SetActive(true);
     
        canvasLevel.gameObject.SetActive(false);
       // canvasGame.gameObject.SetActive(true);
        //imagen.gameObject.SetActive(false);
        //canvasWelcome.gameObject.SetActive(false);
        
        
        Game.GetInstance().SetIsStarted(true);
        Game.GetInstance().StartGame();
        //Main.GetInstance().StartGame();
    }
    public void cambiarNivel(int indice){
        SceneManager.LoadScene(indice);
        canvasLevel.gameObject.SetActive(false);
       // canvasGame.gameObject.SetActive(true);
        //imagen.gameObject.SetActive(false);
        //canvasWelcome.gameObject.SetActive(false);
        
        
        Game.GetInstance().SetIsStarted(true);
        Game.GetInstance().StartGame();
    }
    public void B_NoShow(){
        Debug.Log("Button Clicked! ");
        //botonClose.gameObject.SetActive(false);
        botonStart.gameObject.SetActive(true);

        //texto.enabled = true;
        //canvasWelcome.gameObject.SetActive(true);
        //imagen.gameObject.SetActive(true);

    }
    public static ButtonController GetInstance()
    {
        return instance == null ? instance = new ButtonController() : instance;
    }
}

