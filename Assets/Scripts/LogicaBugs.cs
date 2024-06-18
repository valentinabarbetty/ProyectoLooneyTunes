using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LogicaBugs : MonoBehaviour
{
    public float velocidadMovimiento = 20.0f; // Mayor velocidad
    public float velocidadRotacion = 200.0f;
    public float fuerzaSalto = 5.0f;
    public float fuerzaCaida = 10.0f; // Fuerza adicional para caer más rápido
    private Animator anim;
    private Rigidbody rb;
    private AudioController audioController;
    private float x, y;
    private bool estaEnSuelo;
    private Vector3 posicionInicial;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioController = GetComponent<AudioController>();

        // Guardar la posición inicial
        posicionInicial = transform.position;

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

        // Verificar si AudioController está presente
        if (audioController == null)
        {
            Debug.LogError("No se encontró el componente AudioController.");
        }

        // Cambiar a detección de colisiones continuas dinámicas
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        // Activar interpolación para suavizar el movimiento
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    // Restablecer la posición del personaje
    public void ResetPosition()
    {
        transform.position = posicionInicial;
        rb.velocity = Vector3.zero; // Para asegurarse de que el personaje no siga moviéndose
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

        // Reproducir o detener el sonido de caminar según el movimiento
        if (audioController != null)
        {
            if (x != 0 || y != 0)
            {
                audioController.PlayWalkSound();
            }
            else
            {
                audioController.StopWalkSound();
            }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with enemy.");
            if (GameManager.instance != null)
            {
                GameManager.instance.DecreaseLife();
            }
            else
            {
                Debug.LogError("GameManager.instance is null!");
            }
        }

        if (other.CompareTag("Flag"))
        {
            Debug.Log("toqué la bandera");
            CambiarEscena();
        }

        if (other.CompareTag("notmapa")){
            Debug.Log("Se salio del mapa");
            ResetPosition();
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

    private void CambiarEscena()
    {
        int siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1; // Cambiar al siguiente nivel
        if (siguienteNivel < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguienteNivel);
        }
        else
        {
            Debug.LogError("No hay más niveles disponibles.");
        }
    }

}
