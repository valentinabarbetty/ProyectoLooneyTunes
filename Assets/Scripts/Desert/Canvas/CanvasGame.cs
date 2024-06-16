using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasGameConfig : MonoBehaviour
{
    public Canvas CanvasGame;
    public Canvas CanvasMenu;
    public TMP_Text carrotText;
    public TMP_Text heartText;
    private int carrotCount;
    private int heartCount;
    private const int maxHearts = 3;
    public LogicaBugs logicaBugs;

    void Start()
    {
        carrotCount = 0;
        UpdateCarrotText();
        heartCount = maxHearts;
        UpdateHeartText();

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
