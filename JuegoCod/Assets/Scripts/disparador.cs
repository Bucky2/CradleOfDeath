using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparador : MonoBehaviour
{
    public GameObject bala;
    public Transform spawnPoint;

    public float shotForce = 1500;
    public float shotRate = 0.1f;

    public float shotRateTime = 0;

    // Método para disparar
    public void Disparar()
    {
        if (Time.time > shotRateTime)
        {
            GameObject newBala;

            newBala = Instantiate(bala, spawnPoint.position, spawnPoint.rotation);

            newBala.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

            shotRateTime = Time.time + shotRate;

            Destroy(newBala, 2);
        }
    }
}