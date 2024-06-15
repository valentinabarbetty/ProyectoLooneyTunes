using System.Collections;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    private static Game instance;
    private float speed = 2.0f;
    private bool isStarted = false;
    public GameObject TextTime;
    public TMP_Text TmpText;
    private IEnumerator enumerator;
    private int time;
    private AudioController audioController;

    void Awake()
    {
        instance = this;
        audioController = FindObjectOfType<AudioController>();
        if (audioController == null)
        {
            Debug.LogError("No se encontró el componente AudioController.");
        }
    }

    void Update()
    {
        if (this.isStarted)
        {
            TextTime.SetActive(true);
            TmpText.text = time.ToString();

            if (time == 0)
            {
                // Código de movimiento del jugador, etc.
                TextTime.SetActive(false); // Oculta el texto del tiempo
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && enumerator != null)
        {
            Debug.Log("Stopping coroutine");
            StopCoroutine(enumerator);
        }
    }

    IEnumerator CountDown()
    {
        time = 3;
        do
        {
            Debug.Log(time.ToString() + " seconds left.");
            yield return new WaitForSeconds(1f);
            time--;
        } while (time > 0);
        Debug.Log("Start");

        // Oculta el texto del tiempo
        TextTime.SetActive(false);

        // Inicia el sonido de fondo
        if (audioController != null)
        {
            audioController.PlayBackgroundSound();
        }

        // Start camera movements after countdown
        //StartCoroutine(MoveCameraHorizontally());
        // StartCoroutine(MoveCameraVertically());
    }

    public void SetIsStarted(bool isStarted)
    {
        this.isStarted = isStarted;
    }

    public void StartGame()
    {
        enumerator = CountDown();
        StartCoroutine(enumerator);
    }

    public static Game GetInstance()
    {
        return instance == null ? instance = FindObjectOfType<Game>() : instance;
    }
}
