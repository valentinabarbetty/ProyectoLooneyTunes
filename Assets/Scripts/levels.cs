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

    void Start()
    {
       
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
    }
}
