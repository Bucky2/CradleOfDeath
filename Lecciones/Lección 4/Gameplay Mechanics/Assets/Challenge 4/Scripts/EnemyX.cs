//Creadores: Kevin Leonel Valdez Sánchez && Cristian Israel Buclón Pedroza
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    //Variable para determinar la velocidad de movimiento del enemigo.
    public float speed;
    //Variable para obtener el componente que corresponde al RigidBody.
    private Rigidbody enemyRb;
    //Variable para obtener el componente GameObject del jugador.
    private GameObject playerGoal;
    //Variable para obtener el script SpawnManager y acceder a sus funciones.
    private SpawnManagerX scriptSpawnManagerX;

    // Start is called before the first frame update
    void Start()
    {
        //Se obtiene el objeto que corresponde al RigidBody del enemigo.
        enemyRb = GetComponent<Rigidbody>();
        //Se asigna el componente de nombre Player Goal.
        playerGoal = GameObject.Find("Player Goal");
        //Se asigna el script de nombre Spawn Manager.
        scriptSpawnManagerX = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
        //Se obtiene el valor de la velocidad del enemigo desde el script Spawn Manager.
        speed = scriptSpawnManagerX.enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        //Problema 5:Se aplica fuerza al enemigo para que se mueva hacia la meta.
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            //Se destruye al elemento que corresponde al enemigo.
            Destroy(gameObject);
        } 
        //Valida que el objeto sea la meta del jugador.
        else if (other.gameObject.name == "Player Goal")
        {
            //Destruye al elemento que corresponde al enemigo.
            Destroy(gameObject);
        }

    }

}
