using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Coyote;
    public Transform Yosemite;
    bool isJumping = false;
    public float moveSpeed = 5f;
    public float panSpeed = 10f;

    void Start()
    {
        Debug.Log("Hola mundo");
    }

    // Update is called once per frame
    void Update()
    {
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

                if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        // Movimiento hacia atrás (flecha abajo)
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
        }
        // Movimiento hacia la derecha (flecha derecha)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        // Movimiento hacia la izquierda (flecha izquierda)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
        }
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calcular el desplazamiento de la cámara
        Vector3 pan = new Vector3(mouseX*3, mouseY*3, 0f) * panSpeed * Time.deltaTime;

        // Aplicar el desplazamiento a la posición de la cámara
        transform.Translate(pan, Space.Self);
    }
}

