using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaBugs : MonoBehaviour
{
    public float velocidadMovimiento = 20.0f; // Mayor velocidad
    public float velocidadRotacion = 200.0f;
    public float fuerzaSalto = 5.0f;
    public float fuerzaCaida = 10.0f; // Fuerza adicional para caer más rápido
    private Animator anim;
    private Rigidbody rb;
    private float x, y;
    private bool estaEnSuelo;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // Verificar si Animator está presente
        if (anim == null)
        {
            Debug.LogError("No se encontró el componente Animator.");
        }

        // Verificar si Rigidbody está presente
        if (rb == null)
        {
            Debug.LogError("No se encontró el componente Rigidbody.");
        }

        // Cambiar a detección de colisiones continuas dinámicas
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        // Activar interpolación para suavizar el movimiento
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        // Obtén la entrada del usuario
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Actualizar el Animator si está presente
        if (anim != null)
        {
            anim.SetFloat("VelX", x);
            anim.SetFloat("VelY", y);
        }

        // Comprobar si se presiona la tecla de salto (Space) y si el personaje está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo)
        {
            Saltar();
        }
    }

    void FixedUpdate()
    {
        // Rotación del personaje
        if (x != 0)
        {
            Vector3 rotation = Vector3.up * x * velocidadRotacion * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.Euler(rotation);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        // Movimiento del personaje utilizando Raycasts
        if (y != 0)
        {
            float step = velocidadMovimiento * Time.fixedDeltaTime;
            Vector3 movement = transform.forward * y * step;

            // Usar Raycast para detectar colisiones antes de mover
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, transform.forward, out hit, step))
            {
                rb.MovePosition(rb.position + movement);
            }
            else
            {
                Debug.Log("Obstacle detected: " + hit.collider.name);
            }
        }

        // Aplicar fuerza adicional hacia abajo cuando no está en el suelo
        if (!estaEnSuelo)
        {
            rb.AddForce(Vector3.down * fuerzaCaida);
        }
    }

    void Saltar()
    {
        // Aplicar fuerza hacia arriba para el salto
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        estaEnSuelo = false;

        // Actualizar Animator si está presente
        if (anim != null)
        {
            anim.SetTrigger("Saltar");
            anim.SetBool("EstáSaltando", true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el personaje ha tocado el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnSuelo = true;
            if (anim != null)
            {
                anim.SetBool("EstáSaltando", false);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Verificar si el personaje ha dejado de tocar el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnSuelo = false;
        }
    }
}
