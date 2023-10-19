//Creadores: Kevin Leonel Valdez Sánchez && Cristian Israel Buclón Pedroza
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    //Variable para determinar la velocidad de movimiento.
    private float speed = 200;
    //Variable con el componente de tipo GameObject del jugador.
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        //Variable para obtener el movimiento de tipo horizontal (derecha/izquierda).
        float horizontalInput = Input.GetAxis("Horizontal");
        //Rota el ángulo de la cámara de acuerdo al movimiento de las flechas.
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        transform.position = player.transform.position; // Move focal point with player

    }
}
