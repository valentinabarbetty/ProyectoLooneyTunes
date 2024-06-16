using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private CanvasGameConfig carrotCounter;
    private CanvasGameConfig heartCounter;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            Debug.Log("GameManager instance created.");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignCanvasGameConfig();
    }

    private void AssignCanvasGameConfig()
{
    carrotCounter = FindObjectOfType<CanvasGameConfig>();
    if (carrotCounter == null)
    {
        Debug.LogError("Failed to find CanvasGameConfig for CarrotCounter in the scene!");
    }

    heartCounter = FindObjectOfType<CanvasGameConfig>();
    if (heartCounter == null)
    {
        Debug.LogError("Failed to find CanvasGameConfig for HeartCounter in the scene!");
    }
}


    public void AddCarrot()
    {
        Debug.Log("AddCarrot called.");
        if (carrotCounter != null)
        {
            carrotCounter.AddCarrot();
        }
        else
        {
            Debug.LogError("CarrotCounter is not assigned!");
        }
    }

    public void AddHeart()
    {
        Debug.Log("AddHeart called.");
        if (heartCounter != null)
        {
            heartCounter.AddHeart();
        }
        else
        {
            Debug.LogError("HeartCounter is not assigned!");
        }
    }

    public void DecreaseLife()
    {
        Debug.Log("DecreaseLife called.");
        if (heartCounter != null)
        {
            heartCounter.DecreaseLife();
        }
        else
        {
            Debug.LogError("HeartCounter is not assigned!");
        }
    }
}
