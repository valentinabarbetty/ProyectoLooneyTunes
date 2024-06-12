using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        carrotCount = 0;
        UpdateCarrotText();
        heartCount = maxHearts;
        UpdateHeartText();

        // Verifica si logicaBugs ha sido asignado en el Inspector
        if (logicaBugs == null)
        {
            Debug.LogError("LogicaBugs reference is not assigned!");
        }
    }

    public void AddCarrot()
    {
        carrotCount++;
        UpdateCarrotText();
    }

    public void AddHeart()
    {
        if (heartCount < maxHearts)
        {
            heartCount++;
            UpdateHeartText();
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
    }

    // Update is called once per frame
    void Update()
    {
        B_tecla();
        carrotText.text = "X" + carrotCount;
        heartText.text = "X" + heartCount;
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

        // Restablecer la posición del personaje
        if (logicaBugs != null)
        {
            logicaBugs.ResetPosition();
        }
        else
        {
            Debug.LogError("LogicaBugs reference is not assigned!");
        }

        // Restablecer las vidas a tres
        heartCount = maxHearts;
        UpdateHeartText();

        // Opcional: Puedes agregar más lógica aquí si es necesario
        // como mostrar una pantalla de "Game Over" o reiniciar el nivel.
    }
}
