using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public CanvasGameConfig carrotCounter;
    public CanvasGameConfig heartCounter;
    private int totalCarrots = 0; // Variable para mantener la cuenta total de zanahorias
    private int totalHearts = 3;  // Variable para mantener la cuenta total de corazones
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Suscribir al evento de escena cargada
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AssignCanvasGameConfigReferences();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignCanvasGameConfigReferences();
    }

    private void AssignCanvasGameConfigReferences()
    {
        carrotCounter = FindObjectOfType<CanvasGameConfig>();
        heartCounter = carrotCounter; // Suponiendo que heartCounter es la misma instancia que carrotCounter

        if (carrotCounter == null)
        {
            Debug.LogError("CarrotCounter is not assigned in the new scene!");
        }
        if (heartCounter == null)
        {
            Debug.LogError("HeartCounter is not assigned in the new scene!");
        }

        // Actualizar los contadores en la nueva escena
        if (carrotCounter != null)
        {
            carrotCounter.SetCarrotCount(totalCarrots);
            carrotCounter.SetHeartCount(totalHearts);
        }
    }

    public void AddCarrot()
    {
        totalCarrots++;
        if (carrotCounter != null)
        {
            carrotCounter.AddCarrot();
        }
        else
        {
            Debug.LogError("CarrotCounter is not assigned!");
        }

        // Guardar el total de zanahorias en PlayerPrefs
        PlayerPrefs.SetInt("TotalCarrots", totalCarrots);
    }

    public void AddHeart()
    {
        if (totalHearts < 3) // Suponiendo que 3 es el máximo de corazones
        {
            totalHearts++;
            if (heartCounter != null)
            {
                heartCounter.AddHeart();
            }
            else
            {
                Debug.LogError("HeartCounter is not assigned!");
            }
        }

        // Guardar el total de corazones en PlayerPrefs
        PlayerPrefs.SetInt("TotalHearts", totalHearts);
    }

    public void DecreaseLife()
    {
        totalHearts--;
        if (heartCounter != null)
        {
            heartCounter.DecreaseLife();
        }
        else
        {
            Debug.LogError("HeartCounter is not assigned!");
        }

        // Guardar el total de corazones en PlayerPrefs
        PlayerPrefs.SetInt("TotalHearts", totalHearts);
    }
}