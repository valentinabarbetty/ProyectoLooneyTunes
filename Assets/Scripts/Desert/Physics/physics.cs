using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Rigidbody dardo1;
    public Rigidbody dardo2;
    public Rigidbody dardo3;
    public Rigidbody dardo4;
    public float speed = 50000f;

    private Vector3 initialPosition1;
    private Vector3 finalPosition1;
    private Vector3 initialPosition2;
    private Vector3 finalPosition2;
    private Vector3 initialPosition3;
    private Vector3 finalPosition3;
    private Vector3 initialPosition4;
    private Vector3 finalPosition4;

    void Start()
    {
        // Guardar las posiciones iniciales y finales
        initialPosition1 = new Vector3(-903.11f, -0.41f, 393.56f);
        finalPosition1 = new Vector3(-903.12f, -0.41f, 353.29f);

        initialPosition2 = new Vector3(-907.08f, -0.41f, 393.46f);
        finalPosition2 = new Vector3(-907.09f, -0.41f, 353.18f);

        initialPosition3 = new Vector3(-910.83f, -0.41f, 393.41f);
        finalPosition3 = new Vector3(-910.84f, -0.41f, 353.14f);

        initialPosition4 = new Vector3(-914.71f, -0.34f, 393.41f);
        finalPosition4 = new Vector3(-914.71f, -0.34f, 351.13f);

        // Colocar los dardos en sus posiciones iniciales
        ResetearPosiciones();

        // Iniciar la corutina de lanzamiento de dardos
        StartCoroutine(LanzarDardos());
    }

    private IEnumerator LanzarDardos()
    {
        while (true)
        {
            // Lanzar primer dardo
            yield return StartCoroutine(LanzarDardo(dardo1, finalPosition1));

            // Lanzar segundo dardo
            yield return StartCoroutine(LanzarDardo(dardo2, finalPosition2));

            // Lanzar tercer dardo
            yield return StartCoroutine(LanzarDardo(dardo3, finalPosition3));

            // Lanzar cuarto dardo
            yield return StartCoroutine(LanzarDardo(dardo4, finalPosition4));

            // Esperar un tiempo antes de reiniciar
            yield return new WaitForSeconds(2);

            // Resetear posiciones
            ResetearPosiciones();

            // Esperar un tiempo antes de repetir la secuencia
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator LanzarDardo(Rigidbody dardo, Vector3 finalPosition)
    {
        Debug.Log("Lanzando dardo hacia " + finalPosition);
        Vector3 direction = (finalPosition - dardo.position).normalized;
        float distance = Vector3.Distance(dardo.position, finalPosition);

        while (distance > 0.1f)
        {
            Vector3 move = direction * speed * Time.fixedDeltaTime;
            if (move.magnitude > distance)
            {
                move = direction * distance;
            }
            dardo.MovePosition(dardo.position + move);
            distance = Vector3.Distance(dardo.position, finalPosition);
            Debug.Log("Dardo posición: " + dardo.position + ", Distancia a posición final: " + distance);
            yield return new WaitForFixedUpdate();
        }

        // Detener el dardo en la posición final
        dardo.position = finalPosition;
        Debug.Log("Dardo llegó a la posición final: " + dardo.position);
    }

    private void ResetearPosiciones()
    {
        ResetearDardo(dardo1, initialPosition1);
        ResetearDardo(dardo2, initialPosition2);
        ResetearDardo(dardo3, initialPosition3);
        ResetearDardo(dardo4, initialPosition4);

        Debug.Log("Dardos reiniciados a sus posiciones iniciales.");
    }

    private void ResetearDardo(Rigidbody dardo, Vector3 initialPosition)
    {
        Debug.Log("Reseteando posición del dardo a " + initialPosition);
        dardo.position = initialPosition;
        dardo.velocity = Vector3.zero;
        dardo.angularVelocity = Vector3.zero;
        Debug.Log("Posición del dardo después del reinicio: " + dardo.position);
    }
}
