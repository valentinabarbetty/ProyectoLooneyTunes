using UnityEngine;
using TMPro;

public class CanvasGameConfig : MonoBehaviour
{
    private static CanvasGameConfig instance;
    public Canvas CanvasGame;
    public Canvas CanvasMenu;
    public TMP_Text carrotText;
    public TMP_Text heartText;
    private int carrotCount;
    private int heartCount;
    private const int maxHearts = 3;
    public LogicaBugs logicaBugs; // Referencia al script LogicaBugs

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        InitializeCounters();
    }

    private void InitializeCounters()
    {
        carrotCount = PlayerPrefs.GetInt("TotalCarrots", 0);
        UpdateCarrotText();

        heartCount = PlayerPrefs.GetInt("TotalHearts", maxHearts);
        UpdateHeartText();

        if (logicaBugs == null)
        {
            Debug.LogError("LogicaBugs reference is not assigned!");
        }
    }

    public void SetCarrotCount(int count)
    {
        carrotCount = count;
        UpdateCarrotText();
    }

    public void SetHeartCount(int count)
    {
        heartCount = count;
        UpdateHeartText();
    }

    public void AddCarrot()
    {
        carrotCount++;
        UpdateCarrotText();
        Debug.Log("Zanahoria añadida. Total actual: " + carrotCount);
        // Guardar el nuevo conteo de zanahorias en PlayerPrefs
        PlayerPrefs.SetInt("TotalCarrots", carrotCount);
    }

    public void AddHeart()
    {
        if (heartCount < maxHearts)
        {
            heartCount++;
            UpdateHeartText();
            Debug.Log("Corazón añadido. Total actual: " + heartCount);
            // Guardar el nuevo conteo de corazones en PlayerPrefs
            PlayerPrefs.SetInt("TotalHearts", heartCount);
        }
    }

    public void DecreaseLife()
    {
        heartCount--;
        UpdateHeartText();
        if (heartCount <= 0)
        {
            GameOver();
        }
        Debug.Log("Corazón decrementado. Total actual: " + heartCount);
        // Guardar el nuevo conteo de corazones en PlayerPrefs
        PlayerPrefs.SetInt("TotalHearts", heartCount);
    }

    void Update()
    {
        B_tecla();
    }

    private void UpdateCarrotText()
    {
        carrotText.text = "X" + carrotCount;
    }

    private void UpdateHeartText()
    {
        heartText.text = "X" + heartCount;
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

    public void B_tecla()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasGame.gameObject.SetActive(false);
            CanvasMenu.gameObject.SetActive(true);
            Game.GetInstance().SetIsStarted(false);
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        if (logicaBugs != null)
        {
            logicaBugs.ResetPosition();
        }
        else
        {
            Debug.LogError("LogicaBugs reference is not assigned!");
        }
        heartCount = maxHearts;
        UpdateHeartText();
    }
}