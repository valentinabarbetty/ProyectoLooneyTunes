using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    public bool pasarNivel1;
    public bool pasarNivel2;
    public bool pasarNivel3;
    public bool pasarNivel4;
    public int indiceNivel;
    private static Level instance;

    void Start()
    {
       instance = this;
    }

 void Update()
    {
        //Cambia nivel con la tecla espacio
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            cambiarNivel(indiceNivel);
        }
       if(pasarNivel1)
        {
            cambiarNivel(indiceNivel);
        }*/
    }
public void cambiarNivel(int indice){
        SceneManager.LoadScene(indice);
        Game.GetInstance().SetIsStarted(true);
        Game.GetInstance().StartGame();
    }
        public static Level GetInstance()
    {
        return instance == null ? instance = new Level() : instance;
    }
}
