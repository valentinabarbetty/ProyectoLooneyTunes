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
