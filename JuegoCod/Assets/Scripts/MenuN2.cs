using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class MenuN2 : MonoBehaviour
{
    public Canvas canvasN2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canvasN2 != null)
            {
                canvasN2.gameObject.SetActive(true);

                // Pausar el juego al activar el Canvas
                Time.timeScale = 0f;
            }
        }
    }

    public void ContinueGame()
    {
        // Desactivar el Canvas
        if (canvasN2 != null)
        {
            canvasN2.gameObject.SetActive(false);
        }

        // Reanudar el juego
        Time.timeScale = 1f;
    }

    public void EmpezarNivel2(string NombreNivel)
    {
        // Guardar la puntuación antes de cambiar de nivel
        PlayerPrefs.SetInt("PuntosAcumulados", ControladorPuntos.Instance.puntosNivel);
        
        // Cargar el siguiente nivel
        SceneManager.LoadScene(NombreNivel);
        Time.timeScale = 1f;
    }
}