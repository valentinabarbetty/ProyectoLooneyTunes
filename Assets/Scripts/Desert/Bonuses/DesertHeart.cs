using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertHeart : MonoBehaviour
{
  public Transform heart;
  public Transform[] hearts; // Arreglo de transformaciones de los corazones
   public float heartbeatIntensity = 0.1f; // Intensidad del latido
   public float heartbeatSpeed = 1.0f; // Velocidad del latido
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoverCorazon();

    }

     void MoverCorazon()
    {
        // Para cada corazón en el arreglo
        foreach (Transform heart in hearts)
        {
            // Obtener la posición actual del corazón
            Vector3 position = heart.position;

            // Calcular el factor de escala basado en el coseno del tiempo para simular el latido
            float scale = 1.0f + Mathf.Cos(Time.time * heartbeatSpeed) * heartbeatIntensity;

            // Aplicar el factor de escala a la posición del corazón
            position.y = scale;

            // Actualizar la posición del corazón
            heart.position = position;
        }
    }
}
