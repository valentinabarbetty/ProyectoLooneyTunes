using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CanvasGameConfig carrotCounter;
    public CanvasGameConfig heartCounter;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager instance created.");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (carrotCounter == null || heartCounter == null)
        {
            FindAndAssignCanvasGameConfig();
        }
    }

    private void FindAndAssignCanvasGameConfig()
    {
        CanvasGameConfig[] configs = FindObjectsOfType<CanvasGameConfig>();
        foreach (var config in configs)
        {
            // Assign based on which type it is
            if (config.carrotText != null)
            {
                carrotCounter = config;
            }

            if (config.heartText != null)
            {
                heartCounter = config;
            }
        }

        if (carrotCounter == null)
        {
            Debug.LogError("CarrotCounter is not assigned!");
        }

        if (heartCounter == null)
        {
            Debug.LogError("HeartCounter is not assigned!");
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
