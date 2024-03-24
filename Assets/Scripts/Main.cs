using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Transform samBigotes;
    public Transform carrot1;
    public Transform carrot2;
    public Transform carrot3;
    public Transform heart;

    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 2.0f;

 

    void Start()
    {
        // Desactivar el canvas al inicio

    }

    void Update()
    {
        // Verificar si se presionó la tecla "Escape" (ESC)
        MoverSamBigotes();
        MoverZanahorias();
        RotarCamara();
        MoverJugador();
    }

    // Método para activar o desactivar el canvas


    // Método para mover a Sam Bigotes
    void MoverSamBigotes()
    {
        Vector3 position1 = samBigotes.position;
        position1.x += Mathf.Cos(Time.time) * 5.5f * Time.deltaTime;
        samBigotes.position = position1;
    }

    // Método para mover las zanahorias
    void MoverZanahorias()
    {
        Transform[] zanahorias = { carrot1, carrot2, carrot3 };
        foreach (Transform zanahoria in zanahorias)
        {
            Vector3 position = zanahoria.position;
            position.y += Mathf.Cos(Time.time) * 3.5f * Time.deltaTime;
            zanahoria.position = position;
        }
    }

    // Método para rotar la cámara
    void RotarCamara()
    {
        Quaternion rotacionActual = Camera.main.transform.rotation;
        float rotacionY = Input.GetAxis("Mouse X") * velocidadRotacion;
        float rotacionX = -Input.GetAxis("Mouse Y") * velocidadRotacion;

        // Aplicar la rotación horizontal al objeto (cámara)
        transform.Rotate(0, rotacionY, 0);

        // Rotar la cámara verticalmente
        rotacionX = Mathf.Clamp(rotacionX, -90.0f, 90.0f); // Limitar la rotación vertical
        Camera.main.transform.localRotation *= Quaternion.Euler(rotacionX, 0f, 0f);
    }

    // Método para mover al jugador
    void MoverJugador()
    {
        // Movimiento lateral (izquierda/derecha)
        float movimientoLateral = Input.GetAxis("Horizontal") * velocidadMovimiento * Time.deltaTime;

        // Movimiento vertical (adelante/atrás)
        float movimientoVertical = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;

        // Movimiento hacia adelante y hacia los lados
        transform.Translate(movimientoLateral, 0, movimientoVertical);
    }
}
