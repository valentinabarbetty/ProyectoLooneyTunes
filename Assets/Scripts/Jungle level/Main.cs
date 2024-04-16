using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Coyote;
    public Transform Yosemite;
    private bool isStarted = false;
    bool isJumping = false;
    public float moveSpeed = 5f;
    public float panSpeed = 10f;
    private float speed = 2f;

    public GameObject TextTime;
    private Coroutine coroutine;
    private static Main instance;
    private int time;
    public TMP_Text TmpText;
    private IEnumerator enumerator;

 void Awake(){
        instance = this;
    }

    void Start()
    {
        Debug.Log("Hola mundo");
        // enumerator = CountDown();
        // StartCoroutine(enumerator);
        //coroutine = StartCoroutine(CountDown());
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
        Vector3 position = Coyote.position;
        float verticalSpeed = 2.0f; // Adjust this value for desired vertical speed
        float verticalRange = 4.0f; // Adjust this value for desired vertical range

        // Calculate vertical movement using a sine wave
        float yOffset = Mathf.Sin(Time.time * verticalSpeed) * verticalRange;
        position.y = yOffset + 4; // Offset by 4 units vertically

        Coyote.position = position;

        Vector3 position1 = Yosemite.position;
        // Adjust this value for desired vertical range
        // Calculate vertical movement using a sine wave
        float xOffset = Mathf.Sin(Time.time * verticalSpeed) * verticalRange;
        position1.x = xOffset + 4; // Update position1.x instead of position.x

        Yosemite.position = position1;


        if(Input.GetKeyDown(KeyCode.Escape) && coroutine != null){
            Debug.Log("Stopping coroutine");
            StopCoroutine(coroutine);        
            }
    }

    /*IEnumerator CountDown()
    {
        time = 3;
        do
        {
            Debug.Log(time.ToString() + " seconds left.");
            yield return new WaitForSeconds(1f);
            time--;
        }while(time>0);
        Debug.Log("Start");
    }*/

    public void SetIsStarted(bool isStarted)
    {
        this.isStarted = isStarted;
    }

    /*public void StartGame()
    {
       
        enumerator = CountDown();
        StartCoroutine(enumerator);
    }*/
    
      public static Main GetInstance()
    {
        return instance == null ? instance = new Main() : instance;
    }

}

