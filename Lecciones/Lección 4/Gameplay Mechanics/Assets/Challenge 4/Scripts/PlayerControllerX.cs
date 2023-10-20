//Creadores: Kevin Leonel Valdez Sánchez && Cristian Israel Buclón Pedroza
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    //Variable para obtener el componente que corresponde al RigidBody del jugador.
    private Rigidbody playerRb;
    //Variable para determinar la velocidad del movimiento.
    private float speed = 500;
    //Variable para obtener el objeto correspondiente al punto focal.
    private GameObject focalPoint;
    //Vairable para determinar la velocidad turbo del jugador.
    private float speedFast = 10.0f;

    //Variable para determinar que se tiene un poder activo.
    public bool hasPowerup;
    //Variable para obtener al elemento que corresponde al poder.
    public GameObject powerupIndicator;
    //Variable para determinar la duración del poder activo.
    public int powerUpDuration = 5;
    //Variable para establecer el efecto turbo.
    public ParticleSystem efectoTurbo;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup
    
    void Start()
    {
        //Se asigna el componente RigidBody.
        playerRb = GetComponent<Rigidbody>();
        //Se asigna el componente de nombre Focal Point.
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        //Se aplica fuerza para mover al jugador de acuerdo a las flechas de manera vertical (adelante/atrás).
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        //Valida que se precione la tecla de espacio.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Aplica fuerza al jugador para moverse más rápido.
            playerRb.AddForce(focalPoint.transform.forward *  speedFast, ForceMode.Impulse);
            //Se reproduce el efecto turbo.
            efectoTurbo.Play();
        }
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        //Valida que el objeto con el que choca es un poder.
        if (other.gameObject.CompareTag("Powerup"))
        {
            //Destruye el elemento que corresponde al poder.
            Destroy(other.gameObject);
            //Determina que el jugador cuenta con el poder.
            hasPowerup = true;
            //Muestra el objeto que corresponde al poder-activo.
            powerupIndicator.SetActive(true);
            //Problema 3:Manda llamar a la función que determina el tiempo de duración del poder.
            StartCoroutine(PowerupCooldown()); 
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        //Determina el tiempo que debe durar.
        yield return new WaitForSeconds(powerUpDuration);
        //Desactiva el poder.
        hasPowerup = false;
        //Oculta el objeto que corresponde al poder-activo.
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        //Valida que el elemento con el que choca corresponde al enemigo.
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Variable con el componente RigidBody del enemigo.
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            //Problema 1: Variable que determina la posición del enemigo cuando entra en contacto con el jugador.
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position; 
       
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                //Aplica la fuerza normal en el enemigo para alejarlo del jugador.
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                //Aplica la fuerza con poder en el enemigo para alejarlo del jugador.
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }



}
