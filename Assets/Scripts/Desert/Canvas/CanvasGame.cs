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
        // Add additional game over logic here
        // Restart the game
      //SceneManager.LoadScene(1);
    }

   
}
