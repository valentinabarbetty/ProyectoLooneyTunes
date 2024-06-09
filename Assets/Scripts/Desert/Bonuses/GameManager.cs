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
        Debug.Log("AddCarrot called.");
        if (carrotCounter != null)
        {
            heartCounter.AddHeart();
        }
        else
        {
            Debug.LogError("Heartcounter is not assigned!");
        }
    }
}
