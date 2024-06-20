using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text countdownText; // Referencia al componente Text

    private float countdownTime = 5.0f; // Tiempo inicial de la cuenta regresiva en segundos

    // Start is called before the first frame update
    void Start()
    {
        if (countdownText == null)
        {
            Debug.LogError("No se ha asignado el componente Text en el inspector.");
            return;
        }
        
        StartCoroutine(StartCountdown());
    }

    // Coroutine para la cuenta regresiva
    private IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            countdownText.text = "Tiempo restante: " + countdownTime.ToString("F1");
            yield return new WaitForSeconds(1.0f);
            countdownTime--;
        }
        
        // Una vez que la cuenta regresiva llega a 0
        countdownText.text = "¡Tiempo terminado!";
    }
}
