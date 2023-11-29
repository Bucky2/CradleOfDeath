using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public GameObject Destination;
    NavMeshAgent Agent;
    public int vidas = 0;
    public MovesChava movesChava;
    public Text puntosText; // Referencia al componente Text del objeto de texto en el Canvas
    public int score = 0;

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
                 ControladorPuntos.Instance.SumarPuntos(50);
                
                Destroy(gameObject);
                
                Debug.Log("Total de puntos: " + ControladorPuntos.Instance.puntosNivel);
                
                if (puntosText != null)
                {
                    puntosText.text = "SCORE: " + ControladorPuntos.Instance.puntosNivel.ToString();
                }
            }
        }
        if (other.gameObject.CompareTag("Player"))
        {
            int playerHealthStatus = gameManager.Instance.GetCurrentHealthStatus();

            // Verifica si el jugador está en el estado 2
            if (playerHealthStatus == 2)
            {
                other.gameObject.SetActive(false);

                // Mostrar el Canvas de Game Over
                if (gameManager.Instance.gameOverCanvas != null)
                {
                    gameManager.Instance.gameOverCanvas.gameObject.SetActive(true);
                }

                // Pausar el juego
                Time.timeScale = 0f;
            }
            else
            {
                // Si no, realiza la transición de estado normal
                StartCoroutine(gameManager.Instance.ChangePlayerHealthStatusOverTime());
            }
        }
    }
}
