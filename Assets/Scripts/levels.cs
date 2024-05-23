using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public Canvas CanvasMenu;
    public Canvas CanvasLevels;
    public Canvas CanvasGame;
    public bool pasarNivel1;
    public bool pasarNivel2;
    public bool pasarNivel3;
    public bool pasarNivel4;
    public int indiceNivel;

    void Start()
    {
        // Inicializar si es necesario
    }

    void Update()
    {
        // Si necesitas alguna lógica de actualización aquí
    }

    public void cambiarNivel(int indice)
    {
        if (indice >= 0 && indice < SceneManager.sceneCountInBuildSettings)
        {
            CanvasGame.gameObject.SetActive(true);
            CanvasLevels.gameObject.SetActive(false);
            SceneManager.LoadScene(indice);
        }
        else
        {
            Debug.LogError("Índice de nivel no válido.");
        }
    }

    public void B_OnHandleButtonMenu()
    {
        CanvasLevels.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(true);
    }
}
