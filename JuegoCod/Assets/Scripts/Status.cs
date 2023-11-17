using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Status : MonoBehaviour
{
    public Sprite[] healthStatus; // Array que almacena los diferentes estados de salud
    public Image vida;
    public float scrollSpeed = 10f;

    private Image m_Image;
    private int currentHealthStatus = 0; // Variable para rastrear el estado de salud actual
    private Sprite h_Status;

    void Start()
    {
        m_Image = GetComponent<Image>();
        m_Image.color = new Color32(0, 255, 0, 255);
        h_Status = healthStatus[0];
    }

    void Update()
    {
        vida.GetComponent<Image>().sprite = h_Status;
        m_Image.material.mainTextureOffset = m_Image.material.mainTextureOffset + new Vector2(Time.deltaTime * (-scrollSpeed / 10), 0f);

        // Puedes cambiar esto a una función que llame GameManager para obtener el estado actual del jugador
        // y luego asignar el estado de salud correspondiente
        UpdateHealthStatus(gameManager.Instance.GetCurrentHealthStatus());
    }

    // Esta función se llama cuando cambia el estado de salud del jugador
    public void UpdateHealthStatus(int newHealthStatus)
    {
        currentHealthStatus = newHealthStatus;

        switch (currentHealthStatus)
        {
            case 0:
                m_Image.color = new Color32(0, 255, 0, 255);
                h_Status = healthStatus[0];
                break;
            case 1:
                m_Image.color = new Color32(255, 255, 0, 255);
                h_Status = healthStatus[1];
                break;
            case 2:
                m_Image.color = new Color32(255, 0, 0, 255);
                h_Status = healthStatus[2];
                break;
            case 3:
                HandleGameOver();
                break;

            default:
                break;
        }

         void HandleGameOver()
        {
            // Agrega aquí cualquier código que desees ejecutar cuando el estado de salud sea 3 (Game Over)
            Debug.Log("Game Over");
            // Por ejemplo, podrías cargar una escena de Game Over o reiniciar el juego
            // SceneManager.LoadScene("GameOverScene");
        }
    }
}

