using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour

{
    public GameObject Destination;
    NavMeshAgent Agent;
    public int vidas = 0;
    public MovesChava movesChava;

    
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        movesChava = GameObject.Find("ChavaPlayer").GetComponent<MovesChava>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(Destination.transform.position);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            Debug.Log(" total de vidas " + vidas);

            Destroy(other.gameObject);

            if (++vidas > 3)
            {
                movesChava.puntos += 50;
                Destroy(gameObject);
                Debug.Log(" total de puntos " + movesChava.puntos);
            }

        }
        if (other.gameObject.CompareTag("Player"))
        {
            int playerHealthStatus = gameManager.Instance.GetCurrentHealthStatus();

            // Verifica si el jugador está en el estado 2
            if (playerHealthStatus == 2)
            {
                // Llama al método HandleGameOver en lugar de GetCurrentHealthStatus
                gameManager.Instance.HandleGameOver();
            }
            else
            {
                // Si no, realiza la transición de estado normal
                StartCoroutine(gameManager.Instance.ChangePlayerHealthStatusOverTime());
            }

        }
      


    }

}
