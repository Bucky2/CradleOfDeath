//Creadores: Kevin Leonel Valdez Sánchez && Cristian Israel Buclón Pedroza
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    //Vairable con el elemento de tipo GameObject del enemigo.
    public GameObject enemyPrefab;
    //Variable con el elemento de tipo GameObject del poder.
    public GameObject powerupPrefab;

    //Variable para determinar el rango en el que pueden aparecer los objetos.
    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    //Variable para contar los enemigos.
    public int enemyCount;
    //Problema 4: Variable contar el número de oleada.
    public int waveCount = 1;
    //Variable para controlar la velocidad del enemigo.
    public float enemySpeed = 50.0f;


    public GameObject player; 

    // Update is called once per frame
    void Update()
    {
        //Asigna el objeto con nombre Enemy.
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Valida que no haya enemigos en la escena de juego.
        if (enemyCount == 0)
        {
            //Problema 2:Llama a la función para generar una nueva oleada de enemigos.
            SpawnEnemyWave(waveCount);
        }

    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition ()
    {
        //Variable para definir el límite de la x.
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        //Variable para definir el límite de la z.
        float zPos = Random.Range(spawnZMin, spawnZMax);
        //Regresa el valor de la posición aleatoria.
        return new Vector3(xPos, 0, zPos);
    }

    //Método para generar una nueva oleada de enemigos.
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            //Se genera un nuevo elemento de tipo poder.
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //Genera un nuevo elemento de tipo enemigo.
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        //Aumenta el valor de la oleada / enemigos.
        waveCount++;
        //Aumenta la velocidad de los enemigos.
        enemySpeed += 25;
        ResetPlayerPosition(); // put player back at start

    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition ()
    {
        //Cambia la posición del jugador.
        player.transform.position = new Vector3(0, 1, -7);
        //Cambia la vlocidad del jugador.
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //Cambia la velocidad angular del jugador.
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
