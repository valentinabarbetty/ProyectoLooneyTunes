using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isStarted)
        {
            TextTime.SetActive(true);
            TmpText.text = time.ToString();

            if (time == 0)
            {
                TextTime.SetActive(false);
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");

                Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
                transform.Translate(moveDirection * speed * Time.deltaTime);

                float mouseX = Input.GetAxis("Mouse X");
                transform.Rotate(Vector3.up * mouseX);
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
