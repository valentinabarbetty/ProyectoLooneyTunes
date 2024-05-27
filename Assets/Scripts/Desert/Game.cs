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

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (this.isStarted)
        {
            TextTime.SetActive(true);
            TmpText.text = time.ToString();

            if (time == 0)
            {
                // TextTime.SetActive(false);
                // float horizontalInput = Input.GetAxis("Horizontal");
                // float verticalInput = Input.GetAxis("Vertical");

                // Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
                // transform.Translate(moveDirection * speed * Time.deltaTime);

                // float mouseX = Input.GetAxis("Mouse X");
                // transform.Rotate(Vector3.up * mouseX);
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

        // Start camera movements after countdown
        //StartCoroutine(MoveCameraHorizontally());
        // StartCoroutine(MoveCameraVertically());
    }

    // IEnumerator MoveCameraHorizontally()
    // {
    //     float duration = 6f; // Decreased duration for faster movement
    //     float elapsedTime = 0f;
    //     Vector3 startPosition = transform.position;
    //     Vector3 targetPosition = new Vector3(60f, transform.position.y, 100f); // Adjust X value as needed

    //     while (elapsedTime < duration)
    //     {
    //         transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }
    //     Debug.Log("Horizontal camera movement stopped.");
    // }

    // IEnumerator MoveCameraVertically()
    // {
    //     float duration = 20f; // Decreased duration for faster movement
    //     float elapsedTime = 0f;
    //     Vector3 startPosition = transform.position;
    //     Vector3 targetPosition = new Vector3(transform.position.x, 30f, 100f); // Adjust Y value as needed

    //     while (elapsedTime < duration)
    //     {
    //         transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }
    //     Debug.Log("Vertical camera movement stopped.");
    // }

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
