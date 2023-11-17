using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;

    public Status hud;

    private int currentHealthStatus = 0; // Asumiendo que currentHealthStatus es de tipo int
    private int nextHealthStatus = 0;
    private void Awake()
    {
        Instance = this;
    }

    // Cambié el nombre de la variable para evitar confusión

    public void HandleGameOver()
    {
        // Agrega aquí cualquier código que desees ejecutar cuando se provoque el Game Over
        Debug.Log("Game Over");
        // Por ejemplo, podrías cargar una escena de Game Over o reiniciar el juego
        // SceneManager.LoadScene("GameOverScene");
    }


    // Método para cambiar el estado del jugador con interpolación
    public IEnumerator ChangePlayerHealthStatusOverTime()
    {
        float elapsedTime = 0f;
        float transitionTime = 0.3f;

        int startHealthStatus = currentHealthStatus;
        int targetHealthStatus = (nextHealthStatus + 1) % 3;

        while (elapsedTime < transitionTime)
        {
            currentHealthStatus = (int)Mathf.Lerp(startHealthStatus, targetHealthStatus, elapsedTime / transitionTime);
            hud.UpdateHealthStatus(currentHealthStatus);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        currentHealthStatus = targetHealthStatus;
        hud.UpdateHealthStatus(currentHealthStatus);

        // Actualiza nextHealthStatus después de completar la transición
        nextHealthStatus = (nextHealthStatus + 1) % 3;
    }

    public int GetCurrentHealthStatus()
    {
        return currentHealthStatus;
    }
}